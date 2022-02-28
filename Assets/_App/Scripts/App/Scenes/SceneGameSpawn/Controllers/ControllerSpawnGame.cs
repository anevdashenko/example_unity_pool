using System;
using System.Collections;
using System.Collections.Generic;
using _App.Scripts.App.Common.View.unit;
using _App.Scripts.Core.Entities.common;
using _App.Scripts.Core.Entities.Unit.Base;
using _App.Scripts.Core.Entities.Unit.components;
using _App.Scripts.Core.Services.field;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _App.Scripts.App.Scenes.SceneGameSpawn.Controllers
{
    public class ControllerSpawnGame : MonoBehaviour
    {
        [SerializeField]
        private GameObject viewContainer;

        [SerializeField]
        private ViewUnit viewUnitPrefab;

        [SerializeField]
        private Settings settings;

        private WaitForSeconds _delaySpawn;

        private List<UnitContainer> _units = new List<UnitContainer>();

        private void Awake()
        {
            _delaySpawn = new WaitForSeconds(settings.spawnDelay);

            StartCoroutine(SpawnUnits());
        }

        private IEnumerator SpawnUnits()
        {
            while (true)
            {
                ProcessSpawnUnit();
                yield return _delaySpawn;
            }
        }

        private void ProcessSpawnUnit()
        {
            var spawnPosition = GenerateSpawnPosition();

            var unitView = Instantiate(viewUnitPrefab);
            var forceFall = settings.forceFall.GetLinearValue(Random.value) * new Vector3(0, -1, 0);
            
            var unit = new UnitContainer();
            var componentTransform = new ComponentTransform(spawnPosition);
            var componentPush =  new ComponentForcePush(componentTransform);
            
            unit.AddComponent(componentTransform);
            unit.AddComponent(new ComponentView(unitView, componentTransform));
            unit.AddComponent(componentPush);
            unit.AddComponent(new ComponentDirectionConstantPush(componentPush, forceFall));
            
            _units.Add(unit);
        }

        private Vector3 GenerateSpawnPosition()
        {
            var fieldSize = FieldSizeProviderCamera.Instance.FieldRect;

            var xRandom = Random.value * (fieldSize.width - settings.offsetSize.x * 2);

            return new Vector3(fieldSize.position.x + xRandom + settings.offsetSize.x,
                fieldSize.yMax + settings.offsetSize.y, 0);
        }

        private void Update()
        {
            UpdateUnits();
            CheckRemoveBorderUnits();
        }

        private void UpdateUnits()
        {
            foreach (var container in _units)
            {
                container.Update();
            }
        }

        private void CheckRemoveBorderUnits()
        {
            var fieldSize = FieldSizeProviderCamera.Instance.FieldRect;
            
            for(int i = _units.Count - 1; i >= 0; i--)
            {
                var unit = _units[i];
                var componentTransform = unit.GetComponent<ComponentTransform>();
                
                if (componentTransform.Position.y < fieldSize.yMin)
                {
                    unit.Clear();
                    _units.RemoveAt(i);
                }
            }
        }
        
        [Serializable]
        public class Settings
        {
            public float spawnDelay;
            public Vector2 offsetSize = new Vector2(1, 1);

            public MinMaxValue forceFall;
        }
        
    }
}