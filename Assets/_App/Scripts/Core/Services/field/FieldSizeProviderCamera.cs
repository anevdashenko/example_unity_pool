using _App.Scripts.Libs.Singletons.Unity;
using UnityEngine;

namespace _App.Scripts.Core.Services.field
{
    public class FieldSizeProviderCamera : SingletonMono<FieldSizeProviderCamera>
    {
        [SerializeField]
        private Camera cameraField;
        
        public Rect FieldRect { get; private set; }

        protected override void OnAwake()
        {
            base.OnAwake();

            UpdateFieldSize();
        }

        private void UpdateFieldSize()
        {
            var positionBottomLeft = cameraField.ViewportToWorldPoint(Vector3.zero);
            var positionTopRight = cameraField.ViewportToWorldPoint(Vector3.one);
            
            FieldRect = new Rect(positionBottomLeft, positionTopRight - positionBottomLeft);
        }
    }
}