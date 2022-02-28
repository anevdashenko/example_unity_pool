using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using _App.Scripts.App.Scenes.SceneTestUnit.Models;
using _App.Scripts.Core.Entities.Unit.Base;
using _App.Scripts.Core.Entities.Unit.components;
using TMPro;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneTestUnit.Controllers
{
    public class ControllerTestGetComponent : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI textLog;

        [SerializeField]
        private float delayTest = 3f;

        [SerializeField]
        private int countUnits = 100; 
        
        private List<UnitContainer> _units = new List<UnitContainer>();
        private List<GameObject> _gameObjects = new List<GameObject>();
        
        private void Awake()
        {
            PrepareTestData();
            StartCoroutine(DelayTest());
        }

        private void PrepareTestData()
        {
            for (int i = 0; i < countUnits; i++)
            {
                _units.Add(new UnitContainer());
                _gameObjects.Add(new GameObject($"unit_{i}"));
            }
        }

        private IEnumerator DelayTest()
        {
            yield return new WaitForSeconds(delayTest);
            
            ProcessTest();
        }

        private void ProcessTest()
        {
            var log = new StringBuilder();
            var stopwatch = new Stopwatch();
            
            TestAddComponent(stopwatch, log);
            TestGetComponent(stopwatch, log);
            TestRemoveComponent(stopwatch, log);            

            textLog.text = log.ToString();
        }

        private void TestAddComponent(Stopwatch stopwatch, StringBuilder log)
        {
            //test add component
            stopwatch.Restart();
            
            for (int i = 0; i < countUnits; i++)
            {
                _units[i].AddComponent(new ComponentTransform());
            }
            
            stopwatch.Stop();

            log.Append($"unit add component {stopwatch.ElapsedMilliseconds}\n");
            
            stopwatch.Restart();
            
            for (int i = 0; i < countUnits; i++)
            {
                _gameObjects[i].AddComponent<MonoMoveComponent>();
            }
            
            stopwatch.Stop();

            log.Append($"gameObject add component {stopwatch.ElapsedMilliseconds}\n");
        }

        private void TestGetComponent(Stopwatch stopwatch, StringBuilder log)
        {
            //test add component
            stopwatch.Restart();
            
            for (int i = 0; i < countUnits; i++)
            {
                var componentTransform = _units[i].GetComponent<ComponentTransform>();
                componentTransform.Position += Vector3.one;;
            }
            
            stopwatch.Stop();

            log.Append($"unit get component {stopwatch.ElapsedMilliseconds}\n");
            
            stopwatch.Restart();
            
            for (int i = 0; i < countUnits; i++)
            {
                _gameObjects[i].TryGetComponent<MonoMoveComponent>(out var component);
                component.Position += Vector3.one;
            }
            
            stopwatch.Stop();

            log.Append($"gameObject get component {stopwatch.ElapsedMilliseconds}\n");
        }
        
        private void TestRemoveComponent(Stopwatch stopwatch, StringBuilder log)
        {
            //test add component
            stopwatch.Restart();
            
            for (int i = 0; i < countUnits; i++)
            {
                _units[i].RemoveByType<ComponentTransform>();
            }
            
            stopwatch.Stop();

            log.Append($"unit remove component {stopwatch.ElapsedMilliseconds}\n");
            
            stopwatch.Restart();
            
            for (int i = 0; i < countUnits; i++)
            {
                Destroy(_gameObjects[i].GetComponent<MonoMoveComponent>());
            }
            
            stopwatch.Stop();

            log.Append($"gameObject remove component {stopwatch.ElapsedMilliseconds}\n");
        }

    }
}