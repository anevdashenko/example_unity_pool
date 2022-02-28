using _App.Scripts.Core.Entities.Unit.Base;
using UnityEngine;

namespace _App.Scripts.Core.Entities.Unit.components
{
    public class ComponentForcePush : UnitComponent
    {
        private readonly ComponentTransform _componentTransform;

        private Vector3 _pushForce;
        
        public ComponentForcePush(ComponentTransform componentTransform)
        {
            _componentTransform = componentTransform;
        }

        public void AddForce(Vector3 force)
        {
            _pushForce += force;
        }
        
        public override void Update()
        {
            var deltaPush = Time.deltaTime * _pushForce;

            _componentTransform.Position += deltaPush;
            
            _pushForce = Vector3.zero;
        }
    }
}