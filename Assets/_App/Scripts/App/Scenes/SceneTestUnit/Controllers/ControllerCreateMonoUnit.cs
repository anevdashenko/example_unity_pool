using System;
using System.Collections;
using _App.Scripts.App.Scenes.SceneTestUnit.enums;
using _App.Scripts.App.Scenes.SceneTestUnit.Services.UnitFactory;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneTestUnit.Controllers
{
    public class ControllerCreateMonoUnit : MonoBehaviour
    {
        [SerializeField]
        private float SpawnDelay = 1.3f;

        private WaitForSeconds _delaySpawn;

        private void Awake()
        {
            _delaySpawn = new WaitForSeconds(SpawnDelay);
            StartCoroutine(SpawnUnits());
        }

        private IEnumerator SpawnUnits()
        {
            while (true)
            {
                SpawnRandomUnit();
                yield return _delaySpawn;
            }
        }

        private void SpawnRandomUnit()
        {
            Debug.Log("unit created !");
            var unit = UnitFactoryDummy.Instance.CreateUnit(UnitMonoType.Soldier);
        }
    }
}