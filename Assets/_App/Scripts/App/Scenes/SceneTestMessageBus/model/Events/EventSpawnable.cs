using _App.Scripts.Libs.MessageBusDummy;
using _App.Scripts.Libs.Spawn.Pool;

namespace _App.Scripts.App.Scenes.SceneTestMessageBus.model.Events
{
    public class EventSpawnable : BaseEvent, ISpawnableItem
    {
        private IObjectPool _pool;

        public void OnCreated(IObjectPool objectPool)
        {
            _pool = objectPool;
        }

        public void OnSpawned()
        {
        }

        public void OnDespawned()
        {
        }

        public void OnRemoved()
        {
        }

        public void Remove()
        {
            _pool?.Despawn(this);
        }
    }
}