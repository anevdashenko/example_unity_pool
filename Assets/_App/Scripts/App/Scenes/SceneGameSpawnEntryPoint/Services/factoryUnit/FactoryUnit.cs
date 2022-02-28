using System;
using _App.Scripts.App.Common.View.unit;
using _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Services.FactoryUnit;
using _App.Scripts.Core.Entities.common;
using _App.Scripts.Core.Entities.Unit.Base;
using _App.Scripts.Core.Entities.Unit.components;
using _App.Scripts.Libs.Spawn.Pool;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Services.factoryUnit
{
    public class FactoryUnit : IFactoryUnit
    {
        private readonly Settings _settings;
        private readonly ObjectPoolMono<ViewUnit> _factoryView;


        public FactoryUnit(Settings settings, ObjectPoolMono<ViewUnit> factoryView)
        {
            _settings = settings;
            _factoryView = factoryView;
        }
        
        public UnitContainer Spawn(UnitSpawnContext unitSpawnContext)
        {
            var unitView = _factoryView.Spawn();
            var forceFall = _settings.forceFall.GetLinearValue(Random.value) * new Vector3(0, -1, 0);
            
            var unit = new UnitContainer();
            var componentTransform = new ComponentTransform(unitSpawnContext.SpawnPosition);
            var componentPush =  new ComponentForcePush(componentTransform);
            
            unit.AddComponent(componentTransform);
            unit.AddComponent(new ComponentView(unitView, componentTransform));
            unit.AddComponent(componentPush);
            unit.AddComponent(new ComponentDirectionConstantPush(componentPush, forceFall));

            return unit;
        }
        
        [Serializable]
        public class Settings
        {
            public MinMaxValue forceFall;
        }
    }
}