using _App.Scripts.Core.Entities.Unit.Base;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneGameSpawnFacpool.Services.FactoryUnit
{
    public abstract class AbstractFactoryUnit : MonoBehaviour, IFactoryUnit
    {
        public abstract UnitContainer Spawn(UnitSpawnContext spawnContext);
    }
}