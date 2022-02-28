using System;
using System.Collections.Generic;

namespace _App.Scripts.Core.Entities.Unit.Base
{
    public class UnitContainer
    {
        private const int initComponentSize = 20;
        
        private Dictionary<Type, int> _componentsIndexes = new Dictionary<Type, int>(initComponentSize);
        private List<UnitComponent> _componentsList = new List<UnitComponent>(initComponentSize);
        
        
        public T AddComponent<T>(T component) where T : UnitComponent
        {
            var typeComponent = component.GetType();
            var index = _componentsList.Count;
            _componentsIndexes[typeComponent] = index;
            component.OnAdded(this);
            _componentsList.Add(component);
            
            return component;
        }

        public void RemoveComponent(UnitComponent component)
        {
            var type = component.GetType();
            if (!_componentsIndexes.TryGetValue(type, out var removeIndex))
            {
                return;
            }
            
            _componentsIndexes.Remove(type);
            
            if (removeIndex >= 0)
            {
                _componentsList[removeIndex] = _componentsList[_componentsList.Count - 1];
                _componentsList.RemoveAt(_componentsList.Count - 1);
            }
        }

        public void RemoveByType<T>() where T : UnitComponent
        {
            var typeComponent = typeof(T);
            if (_componentsIndexes.TryGetValue(typeComponent, out var removeIndex))
            {
                RemoveComponent(_componentsList[removeIndex]);
            }
        }

        public T GetComponent<T>() where T : UnitComponent
        {
            var typeComponent = typeof(T);
            if (_componentsIndexes.TryGetValue(typeComponent, out var index))
            {
                return _componentsList[index] as T;
            }

            return null;
        }

        public bool TryGetComponent<T>(out T component) where T : UnitComponent
        {
            var typeComponent = typeof(T);

            var result= _componentsIndexes.TryGetValue(typeComponent, out var index);
            component = _componentsList[index] as T;

            return result;
        }

        public void Update()
        {
            foreach (var component in _componentsList)
            {
                component.Update();
            }
        }

        public void Clear()
        {
            foreach (var component in _componentsList)
            {
                component.Clear();
            }
        }

        
    }
}