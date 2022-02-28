using System;

namespace _App.Scripts.Libs.MessageBusDummy
{
    public interface IEventHandlerContainer
    {
        void Raise<T>(T eventData) where T : BaseEvent;
        ISubscription Subscribe<T>(Action<T> handler) where T : BaseEvent;
    }
}