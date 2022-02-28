using _App.Scripts.App.Scenes.SceneTestMessageBus.Config.Settings;
using _App.Scripts.App.Scenes.SceneTestMessageBus.model.Events;
using _App.Scripts.Libs.Debug.FuncAnalize;
using _App.Scripts.Libs.Spawn.Pool;
using MessagePipe;
using UnityEngine.Profiling;

namespace _App.Scripts.App.Scenes.SceneTestMessageBus.Controllers.MessagePipe
{
    public class ControllerStartGame : Zenject.IInitializable
    {
        private readonly ViewButton _buttonGameStart;
        private readonly IPublisher<EventGameComplete> _publisher;
        private readonly IObjectPool<EventGameComplete> _objectPool;
        private readonly SettingsTest _settings;

        public ControllerStartGame(ViewButton buttonGameStart, IPublisher<EventGameComplete> publisher, IObjectPool<EventGameComplete> objectPool, SettingsTest settings)
        {
            _buttonGameStart = buttonGameStart;
            _publisher = publisher;
            _objectPool = objectPool;
            _settings = settings;
        }
        
        public void Initialize()
        {
            _buttonGameStart.OnClicked += OnButtonClicked;
        }

        private void OnButtonClicked()
        {
            Profiler.BeginSample(_settings.NameSample);
            var eventData = _objectPool.Spawn();
            using (new PerfScanner("message pipe"))
            {
                for (int i = 0; i < _settings.countSendMessage; i++)
                {
                    _publisher.Publish(eventData);
                }
            }

            eventData.Remove();
            Profiler.EndSample();
        }
    }
}