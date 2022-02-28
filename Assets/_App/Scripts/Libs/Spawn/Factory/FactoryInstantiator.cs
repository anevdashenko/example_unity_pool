using System;

namespace _App.Scripts.Libs.Spawn.Factory
{
    public class FactoryInstantiator<T> : IFactory<T>
    {
        private readonly Func<T> _instantiator;

        public FactoryInstantiator(Func<T> instantiator)
        {
            _instantiator = instantiator ?? throw new ArgumentNullException(nameof(instantiator));
        }
        
        public T Spawn()
        {
            return _instantiator.Invoke();
        }
    }
}