using System;
using UnityEngine;
using UnityEngine.UI;

namespace _App.Scripts.App.Scenes.SceneTestMessageBus
{
    public class ViewButton : MonoBehaviour
    {
        [SerializeField]
        private Button button; 
        
        public event Action OnClicked;

        private void Awake()
        {
            button.onClick.AddListener(() =>
            {
                OnClicked?.Invoke();
            });
        }
    }
}