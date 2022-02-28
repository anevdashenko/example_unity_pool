using _App.Scripts.Core.Entities.Unit.Base;
using UnityEngine;

namespace _App.Scripts.Core.Entities.Unit.components
{
    public class ComponentDirectionConstantPush : UnitComponent
    {
        private readonly ComponentForcePush _componentForcePush;
        private readonly Vector3 _pushForce;

        public ComponentDirectionConstantPush(ComponentForcePush componentForcePush, Vector3 pushForce)
        {
            _componentForcePush = componentForcePush;
            _pushForce = pushForce;
        }

        public override void Update()
        {
            _componentForcePush.AddForce(_pushForce);
        }
    }
}