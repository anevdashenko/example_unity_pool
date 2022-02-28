using _App.Scripts.App.Common.View.unit;
using _App.Scripts.Core.Entities.Unit.Base;
using UnityEngine;

namespace _App.Scripts.Core.Entities.Unit.components
{
    public class ComponentView : UnitComponent
    {
        private ViewUnit _viewUnit;
        private readonly ComponentTransform _componentTransform;

        public ComponentView(ViewUnit viewUnit, ComponentTransform componentTransform)
        {
            _viewUnit = viewUnit;
            _componentTransform = componentTransform;
        }
        
        public override void Update()
        {
            _viewUnit.transform.position = _componentTransform.Position;
        }

        public override void Clear()
        {
            _viewUnit.Remove();
            _viewUnit = null;
        }
    }
}