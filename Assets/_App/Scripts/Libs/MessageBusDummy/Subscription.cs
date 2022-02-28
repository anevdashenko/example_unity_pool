using System;

namespace _App.Scripts.Libs.MessageBusDummy
{
    public class Subscription<T> : ISubscription  where T : BaseEvent
    {
        private Action<T> handler;

        public bool IsEmpty => handler == null;
        
        public Subscription(Action<T> handler)
        {
            this.handler = handler;
        }
        
        public void Raise(T eventData)
        {
            handler?.Invoke(eventData);
        }

        public void Dispose()
        {
            handler = null;
        }
    }
}