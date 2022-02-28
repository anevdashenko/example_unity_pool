using System;
using _App.Scripts.App.Scenes.SceneTestMessageBus.model.Events;
using MessagePipe;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneTestMessageBus.Controllers.MessagePipe
{
    public class ControllerViewStartGame : Zenject.IInitializable, IDisposable
    {
        private readonly IDisposable _subscription;

        private int score;
        
        public ControllerViewStartGame(ISubscriber<EventGameComplete> subscriberEventComplete)
        {
            _subscription = subscriberEventComplete.Subscribe(OnGameComplete);
        }

        private void OnGameComplete(EventGameComplete obj)
        {
            score += 10;
        }

        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            _subscription?.Dispose();
        }
    }
}