using System;
using System.Collections.Generic;

namespace _App.Scripts.Libs.AppStateMachine
{
    public class StateMachine
    {

        private Dictionary<Type, AppState> _states = new Dictionary<Type, AppState>();

        public AppState CurrentState { get; private set; }

        public void AddState(AppState state)
        {
            var typeState = state.GetType();
            _states[typeState] = state;
            state.OnAddedState(this);
        }

        public void UpdateState()
        {
            CurrentState?.OnUpdateState();
        }
        
        public T ChangeState<T>() where T : AppState
        {
            var typeState = typeof(T);
            if (!_states.TryGetValue(typeState, out var state))
            {
                throw new ArgumentException("State not found");
            }

            ClearCurrentState();
            
            state.OnEnterState();
            
            return state as T;
        }

        public void ClearCurrentState()
        {
            if (CurrentState == null)
            {
                return;
            }
            
            CurrentState.OnExitState();
            CurrentState = null;
        }


        
    }
}