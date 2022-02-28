using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneTestUnit.Models
{
    public class UnitMono : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public void Init(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
    }
}