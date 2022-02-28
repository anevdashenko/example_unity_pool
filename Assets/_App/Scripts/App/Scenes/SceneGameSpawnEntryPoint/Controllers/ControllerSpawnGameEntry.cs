using System;
using System.Collections.Generic;
using _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Services.Field;
using _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Services.FactoryUnit;
using _App.Scripts.Core.Entities.Unit.Base;
using _App.Scripts.Core.Entities.Unit.components;
using _App.Scripts.Libs.AppRoot.interfaces;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Controllers
{
    public class ControllerSpawnGameEntry : IInitializable, ITickable
    {
        private Settings _settings;
        private readonly ProviderFieldSize _fieldSizeProviderCamera;
        private IFactoryUnit _factoryUnitMono;
        
        private readonly List<UnitContainer> _units = new List<UnitContainer>();
        private Tween _delayTween;


        public ControllerSpawnGameEntry(Settings settings, ProviderFieldSize fieldSizeProviderCamera, IFactoryUnit factoryUnitMono)
        {
            _settings = settings;
            _fieldSizeProviderCamera = fieldSizeProviderCamera;
            _factoryUnitMono = factoryUnitMono;
        }
        
        public void Initialize()
        {
            _delayTween = DOVirtual.DelayedCall(_settings.spawnDelay, OnSpawnUnit).SetLoops(-1);
        }

        private void OnSpawnUnit()
        {
            var spawnContext = new UnitSpawnContext
            {
                SpawnPosition = GenerateSpawnPosition()
            };
            
            var unit = _factoryUnitMono.Spawn(spawnContext);
            _units.Add(unit);
        }

        private Vector3 GenerateSpawnPosition()
        {
            var fieldSize = _fieldSizeProviderCamera.FieldRect;

            var xRandom = Random.value * (fieldSize.width - _settings.offsetSize.x * 2);

            return new Vector3(fieldSize.position.x + xRandom + _settings.offsetSize.x,
                fieldSize.yMax + _settings.offsetSize.y, 0);
        }
        
        public void Tick()
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
            var fieldSize = _fieldSizeProviderCamera.FieldRect;
            
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