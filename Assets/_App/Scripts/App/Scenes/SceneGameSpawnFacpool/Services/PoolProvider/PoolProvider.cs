using System;
using _App.Scripts.App.Common.View.unit;
using _App.Scripts.Core.Entities.Prefab;
using _App.Scripts.Libs.Spawn.Pool;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Services.PoolProvider
{
    public class PoolProvider : MonoBehaviour
    {

        [SerializeField]
        private SpawnSettingsPrefab prefabViewUnit;


        public ObjectPoolMono<ViewUnit> PoolViewUnit { get; private set; }


        private void Awake()
        {
            Init();
        }

        public void Init()
        {
            PoolViewUnit = ViewUnit.Pool.CreatePoolMono(prefabViewUnit.Prefab, prefabViewUnit.SpawnCount,
                prefabViewUnit.poolTransform);
        }
        
        

        
    }
}