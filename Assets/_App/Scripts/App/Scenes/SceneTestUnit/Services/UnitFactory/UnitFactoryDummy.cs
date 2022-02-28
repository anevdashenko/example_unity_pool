using _App.Scripts.App.Common.View.unit;
using _App.Scripts.App.Scenes.SceneTestUnit.enums;
using _App.Scripts.Libs.Singletons.Unity;
using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneTestUnit.Services.UnitFactory
{
    public sealed class UnitFactoryDummy : SingletonMono<UnitFactoryDummy>
    {
        protected override void OnAwake()
        {
            base.OnAwake();
            
        }

        public ViewUnit CreateUnit(UnitMonoType unitMonoType)
        {
            Debug.Log("creating mono unit");
            if (gameObject.activeSelf)
            {
                Debug.Log("ready to spawn!");
            }
            return null;
        }

  
    }
}