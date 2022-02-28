namespace _App.Scripts.Libs.Spawn.Factory
{
    public interface IFactory<out T>
    {
        T Spawn();
    }
    
    public interface IFactory<out T, in TParam1>
    {
        T Spawn(TParam1 param1);
    }
    
    public interface IFactory<out T, in TParam1, in TParam2>
    {
        T Spawn(TParam1 param1, TParam2 param2);
    }
}