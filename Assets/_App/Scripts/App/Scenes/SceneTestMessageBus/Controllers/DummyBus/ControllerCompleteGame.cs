using System;
using _App.Scripts.App.Scenes.SceneTestMessageBus.model.Events;
using _App.Scripts.Libs.MessageBusDummy;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneTestMessageBus.Controllers
{
    public class ControllerCompleteGame : Zenject.IInitializable, IDisposable
    {
        private readonly MessageBusDummy _messageBus;
        private ISubscription _subscriptionGameComplete;

        private int score = 10;
        
        public ControllerCompleteGame(MessageBusDummy messageBus)
        {
            _messageBus = messageBus;
        }
        
        public void Initialize()
        {
            _subscriptionGameComplete = _messageBus.Subscribe<EventGameComplete>(OnGameComplete);
        }

        private void OnGameComplete(EventGameComplete eventGameComplete)
        {
            score += 10;
        }

        public void Dispose()
        {
            _subscriptionGameComplete?.Dispose();
        }
    }
}