using System;
using System.Collections.Generic;

namespace _App.Scripts.Libs.MessageBusDummy
{
    public class MessageBusDummy
    {
        private Dictionary<Type, IEventHandlerContainer> _handlers = new Dictionary<Type, IEventHandlerContainer>();
        
        public ISubscription Subscribe<T>(Action<T> handler) where T : BaseEvent
        {
            var typeEvent = typeof(T);

            if (!_handlers.TryGetValue(typeEvent, out var handlerContainer))
            {
                handlerContainer = new HandlerContainer<T>();
                _handlers[typeEvent] = handlerContainer;
            }
            
            return handlerContainer.Subscribe(handler);
        }

        public void Send<T>(T eventData) where T : BaseEvent
        {
            var typeEvent = typeof(T);

            if (_handlers.TryGetValue(typeEvent, out var handlerContainer))
            {
                handlerContainer.Raise(eventData);
            }
        }
    }
}