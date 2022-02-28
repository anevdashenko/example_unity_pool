using UnityEngine;

namespace _App.Scripts.App.Scenes.SceneGameSpawnEntryPoint.Services.Field
{
    public class ProviderFieldSize
    {
        private readonly Camera _camera;

        public Rect FieldRect { get; private set; }
        
        public ProviderFieldSize(Camera camera)
        {
            _camera = camera;
            UpdateFieldSize();
        }
        
        private void UpdateFieldSize()
        {
            var positionBottomLeft = _camera.ViewportToWorldPoint(Vector3.zero);
            var positionTopRight = _camera.ViewportToWorldPoint(Vector3.one);
            
            FieldRect = new Rect(positionBottomLeft, positionTopRight - positionBottomLeft);
        }
    }
}