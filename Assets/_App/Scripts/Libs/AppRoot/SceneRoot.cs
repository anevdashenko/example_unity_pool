using System;
using System.Collections.Generic;
using UnityEngine;

namespace _App.Scripts.Libs.AppRoot
{
    public class SceneRoot : MonoBehaviour
    {
        [SerializeField]
        private List<InstallerMono> installers = new List<InstallerMono>();

        private AppRunner _appRunner;
        
        private void Awake()
        {
            InstallApp();
        }

        private void InstallApp()
        {
            ClearAppRunner();
            
            _appRunner = new AppRunner();
            
            foreach (var installerMono in installers)
            {
                installerMono.Install(_appRunner);
            }
        }

        private void ClearAppRunner()
        {
            if (_appRunner == null)
            {
                return;
            }

            _appRunner.Dispose();
            _appRunner = null;
        }

        private void Start()
        {
            _appRunner.Init();
        }

        private void Update()
        {
            _appRunner.Tick();
        }

        private void OnDestroy()
        {
            ClearAppRunner();
        }
    }
}