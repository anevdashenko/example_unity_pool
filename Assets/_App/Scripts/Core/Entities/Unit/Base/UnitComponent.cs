namespace _App.Scripts.Core.Entities.Unit.Base
{
    public class UnitComponent
    {
        public UnitContainer UnitContainer { get; private set; }
        
        public void OnAdded(UnitContainer unitContainer)
        {
            UnitContainer = unitContainer;
        }

        public virtual void Update()
        {
            
        }

        public virtual void Clear()
        {
        }
    }
}