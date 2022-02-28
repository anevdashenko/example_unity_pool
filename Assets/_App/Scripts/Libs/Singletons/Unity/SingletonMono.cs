using UnityEngine;

namespace _App.Scripts.Libs.Singletons.Unity
{
    public class SingletonMono<T> : MonoBehaviour where T : Component
    {
        private const string SingletonNamePattern = "[Singleton] {0}";
        public bool dontDestroyOnLoad;
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
            
                var objs = FindObjectsOfType(typeof(T));
                if (objs.Length > 0)
                    _instance = (T) objs[0];
                else
                {
                    var singleton = new GameObject();
                    _instance = singleton.AddComponent<T>();
                    DontDestroyOnLoad(singleton.transform.root);
                    singleton.name = string.Format(SingletonNamePattern, typeof(T).Name);
                }

                return _instance;
            }
        }
        private void Awake()
        {
            if (Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            OnAwake();
        }

        protected virtual void OnAwake()
        {
            
        }
    }
}