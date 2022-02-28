using _App.Scripts.Core.Entities.Unit.Base;
using UnityEngine;

namespace _App.Scripts.Core.Entities.Unit.components
{
    public class ComponentTransform : UnitComponent
    {
        public Vector3 Position;
        public Vector3 Scale = Vector3.one;

        public ComponentTransform()
        {
            Position = Vector3.zero;
        }
        
        public ComponentTransform(Vector3 position)
        {
            Position = position;
        }
    }
}