using System;
using _App.Scripts.App.Common.View.unit;
using _App.Scripts.Core.Entities.common;
using _App.Scripts.Core.Entities.Unit.Base;
using _App.Scripts.Core.Entities.Unit.components;
using _App.Scripts.Libs.Spawn.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Services.FactoryUnit
{
    public class FactoryUnitMono : AbstractFactoryUnit
    {
        [SerializeField]
        private ViewUnit prefabViewUnit;

        [SerializeField]
        private PoolProvider.PoolProvider _poolProvider; 
        
        [SerializeField]
        private Settings settings;
        
        public override UnitContainer Spawn(UnitSpawnContext unitSpawnContext)
        {
            var unitView = _poolProvider.PoolViewUnit.Spawn();
            var forceFall =settings.forceFall.GetLinearValue(Random.value) * new Vector3(0, -1, 0);
            
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