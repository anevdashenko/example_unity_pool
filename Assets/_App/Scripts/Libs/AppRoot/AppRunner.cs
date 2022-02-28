using System;
using System.Collections.Generic;
using _App.Scripts.Libs.AppRoot.interfaces;

namespace _App.Scripts.Libs.AppRoot
{
    public class AppRunner
    {
        private List<IInitializable> _initializables = new List<IInitializable>();
        private List<ITickable> _tickables = new List<ITickable>();
        private List<IDisposable> _disposables = new List<IDisposable>();

        public void AddComponent(object component)
        {
            if (component is IInitializable initializable)
            {
                _initializables.Add(initializable);
            }
            
            if (component is ITickable tickable)
            {
                _tickables.Add(tickable);
            }
            
            if (component is IDisposable disposable)
            {
                _disposables.Add(disposable);
            }
        }
        
        public void Init()
        {
            foreach (var initializable in _initializables)
            {
                initializable.Initialize();
            }
        }

        public void Tick()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick();
            }
        }

        public void Dispose()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }
    }
}