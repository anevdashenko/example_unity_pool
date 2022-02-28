using System;
using _App.Scripts.App.Scenes.SceneTestMessageBus.Config.Settings;
using _App.Scripts.App.Scenes.SceneTestMessageBus.model.Events;
using _App.Scripts.Libs.Debug.FuncAnalize;
using _App.Scripts.Libs.MessageBusDummy;
using _App.Scripts.Libs.Spawn.Pool;
using UnityEngine;
using UnityEngine.Profiling;

namespace _App.Scripts.App.Scenes.SceneTestMessageBus.Controllers
{
    public class ControllerTestMessageSend : Zenject.IInitializable
    {
        private readonly MessageBusDummy _messageBus;
        private readonly ViewButton _buttonCompleteGame;
        private readonly IObjectPool<EventGameComplete> _poolEventGameComplete;
        private readonly SettingsTest _settings;

        public ControllerTestMessageSend(MessageBusDummy messageBus, ViewButton buttonCompleteGame,
            IObjectPool<EventGameComplete> poolEventGameComplete, SettingsTest settings)
        {
            _messageBus = messageBus;
            _buttonCompleteGame = buttonCompleteGame;
            _poolEventGameComplete = poolEventGameComplete;
            _settings = settings;
        }
        
        public void Initialize()
        {
            _buttonCompleteGame.OnClicked += OnCompleteGame;
        }

        private void OnCompleteGame()
        {
            Profiler.BeginSample(_settings.NameSample);
            var eventData = _poolEventGameComplete.Spawn();

            using (new PerfScanner("message buss dummy"))
            {
                for (int i = 0; i < _settings.countSendMessage; i++)
                {
                    _messageBus.Send(eventData);
                }
            }

            eventData.Remove();
            Profiler.EndSample();
        }
        
    }
}