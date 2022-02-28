using _App.Scripts.App.Scenes.SceneTestMessageBus.Config.Settings;
using _App.Scripts.App.Scenes.SceneTestMessageBus.Controllers;
using _App.Scripts.App.Scenes.SceneTestMessageBus.Controllers.MessagePipe;
using _App.Scripts.App.Scenes.SceneTestMessageBus.model.Events;
using _App.Scripts.Libs.MessageBusDummy;
using _App.Scripts.Libs.Spawn.Pool;
using MessagePipe;
using UnityEngine;
using Zenject;

namespace _App.Scripts.App.Scenes.SceneTestMessageBus.Installers
{
    public class InstallerTestMessageBus : MonoInstaller
    {
        [SerializeField]
        private ViewButton buttonCompleteGame;

        [SerializeField]
        private ViewButton buttonGameStart;
        
        [SerializeField]
        private SettingsTest settingsButtonClick;
        
        private MessageBusDummy _messageBus;
        private ObjectPool<EventGameComplete> _poolEventGameComplete;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<MessageBusDummy>().AsSingle();
            _poolEventGameComplete = new ObjectPool<EventGameComplete>(() => new EventGameComplete(), 10);
            Container.Bind<IObjectPool<EventGameComplete>>().FromInstance(_poolEventGameComplete).AsSingle();
            Container.BindInterfacesTo<ControllerTestMessageSend>().AsSingle();
            Container.BindInterfacesTo<ControllerCompleteGame>().AsSingle();
            
            Container.BindInterfacesTo<ControllerStartGame>().AsSingle();
            Container.BindInterfacesTo<ControllerViewStartGame>().AsSingle();

            Container.BindInstance(buttonCompleteGame).WhenInjectedInto<ControllerTestMessageSend>();
            Container.BindInstance(buttonGameStart).WhenInjectedInto<ControllerStartGame>();
            Container.BindInstance(settingsButtonClick).AsSingle();
            
            
            
            var options = Container.BindMessagePipe();
    
            Container.BindMessageBroker<EventGameComplete>(options);

            GlobalMessagePipe.SetProvider(Container.AsServiceProvider());
        }
    }
}