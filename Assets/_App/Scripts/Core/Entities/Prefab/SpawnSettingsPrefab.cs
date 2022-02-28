using System;
using UnityEngine;

namespace _App.Scripts.Core.Entities.Prefab
{
    [Serializable]
    public class SpawnSettingsPrefab
    {
        public GameObject Prefab;
        public int SpawnCount;
        public Transform poolTransform;
    }
}