using System;
using System.Collections;
using System.Collections.Generic;
using _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Services.FactoryUnit;
using _App.Scripts.Core.Entities.Unit.Base;
using _App.Scripts.Core.Entities.Unit.components;
using _App.Scripts.Core.Services.field;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Controllers
{
    public class ControllerSpawnPool : MonoBehaviour
    {
        [SerializeField]
        private GameObject viewContainer;

        [SerializeField]
        private Settings settings;

        [SerializeField]
        private AbstractFactoryUnit factoryUnitMono;
        
        private WaitForSeconds _delaySpawn;

        private readonly List<UnitContainer> _units = new List<UnitContainer>();

        private void Start()
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
            var spawnContext = new UnitSpawnContext
            {
                SpawnPosition = GenerateSpawnPosition()
            };
            
            var unit = factoryUnitMono.Spawn(spawnContext);
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
        }
    }
}