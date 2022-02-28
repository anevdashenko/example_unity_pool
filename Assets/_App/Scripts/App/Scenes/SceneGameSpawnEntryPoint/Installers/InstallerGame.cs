using _App.Scripts.App.Common.View.unit;
using _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Controllers;
using _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Services.factoryUnit;
using _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Services.Field;
using _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Services.FactoryUnit;
using _App.Scripts.Core.Entities.Prefab;
using _App.Scripts.Libs.AppRoot;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Installers
{
    public class InstallerGame : InstallerMono
    {
        [SerializeField]
        private Camera fieldCamera;

        [SerializeField]
        private ControllerSpawnGameEntry.Settings _settingsControllerSpawn;

        [SerializeField]
        private FactoryUnit.Settings _settingsFactoryUnit;

        [SerializeField]
        private SpawnSettingsPrefab spawnPrefab;
        
        public override void Install(AppRunner appRunner)
        {
            var pool = ViewUnit.Pool.CreatePoolMono(spawnPrefab.Prefab, spawnPrefab.SpawnCount,
                spawnPrefab.poolTransform);
            
            var factoryUnit = new FactoryUnit(_settingsFactoryUnit, pool);
            var providerFieldSize = new ProviderFieldSize(fieldCamera);
            
            var gameController = new ControllerSpawnGameEntry(_settingsControllerSpawn, providerFieldSize, factoryUnit);
            
            appRunner.AddComponent(gameController);
        }
        
        
    }
}