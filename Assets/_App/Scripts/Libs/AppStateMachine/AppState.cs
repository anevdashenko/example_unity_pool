namespace _App.Scripts.Libs.AppStateMachine
{
    public class AppState
    {
        protected StateMachine stateMachine;

        public void OnAddedState(StateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }
        
        public virtual void OnEnterState()
        {
            
        }

        public virtual void OnExitState()
        {
            
        }

        public virtual void OnUpdateState()
        {
            
        }
        
    }
}