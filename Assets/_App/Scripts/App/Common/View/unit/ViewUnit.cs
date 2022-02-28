using _App.Scripts.Libs.Spawn.Pool;
using UnityEngine;

namespace _App.Scripts.App.Common.View.unit
{
    public class ViewUnit : MonoSpawnableItemItem
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public void Init(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }
        
        public class Pool : ObjectPoolMono<ViewUnit>
        {
        }
    }
}