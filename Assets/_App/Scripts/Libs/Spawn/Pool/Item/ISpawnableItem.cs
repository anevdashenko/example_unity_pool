namespace _App.Scripts.Libs.Spawn.Pool
{
    public interface ISpawnableItem
    {
        void OnCreated(IObjectPool objectPool);
        void OnSpawned();
        void OnDespawned();
        void OnRemoved();
    }
}