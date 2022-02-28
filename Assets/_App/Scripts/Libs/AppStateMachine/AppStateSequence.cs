using System.Collections.Generic;

namespace _App.Scripts.Libs.AppStateMachine
{
    public class AppStateSequence : AppState
    {
        private List<AppState> _innerStates = new List<AppState>();

        public void AddStates(IEnumerable<AppState> states)
        {
            _innerStates.AddRange(states);
        }

        public void AddState(AppState state)
        {
            _innerStates.Add(state);
        }

        public override void OnEnterState()
        {
            base.OnEnterState();
            foreach (var state in _innerStates)
            {
                state.OnEnterState();
            }
        }

        public override void OnExitState()
        {
            base.OnExitState();
            foreach (var state in _innerStates)
            {
                state.OnExitState();
            }
        }

        public override void OnUpdateState()
        {
            base.OnUpdateState();
            foreach (var state in _innerStates)
            {
                state.OnUpdateState();
            }
        }
    }
}