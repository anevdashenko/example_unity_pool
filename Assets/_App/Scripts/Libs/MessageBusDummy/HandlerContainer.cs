using System;
using System.Collections.Generic;

namespace _App.Scripts.Libs.MessageBusDummy
{
    public class HandlerContainer<T> : IEventHandlerContainer where T : BaseEvent
    {
        private List<Subscription<T>> _subscriptions = new List<Subscription<T>>();


        public void Raise<T1>(T1 eventData) where T1 : BaseEvent
        {
            var data = eventData as T;
            if (data == null)
            {
                return;
            }

            ClearSubscriptions();
            foreach (var subscription in _subscriptions)
            {
                
                subscription.Raise(data);
            }
         
        }

        private void ClearSubscriptions()
        {
            for (int i = _subscriptions.Count - 1; i >= 0; i--)
            {
                var subscription = _subscriptions[i];
                
                if (subscription.IsEmpty)
                {
                    _subscriptions.RemoveAt(i);
                }
            }
        }

        public ISubscription Subscribe<T1>(Action<T1> handler) where T1 : BaseEvent
        {
            var subscription = new Subscription<T>((Action<T>)handler);
            _subscriptions.Add(subscription);
            return subscription;
        }
    }
}