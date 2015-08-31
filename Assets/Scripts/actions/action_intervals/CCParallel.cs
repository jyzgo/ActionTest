using System;
using System.Collections.Generic;

using UnityEngine;

namespace MTUnityAction
{
    public class CCParallel : CCFiniteTimeAction
    {
        public CCFiniteTimeAction[] Actions { get; private set; }

        #region Constructors

        public CCParallel (params CCFiniteTimeAction[] actions) : base ()
        {
            // Can't call base(duration) because max action duration needs to be determined here
            float maxDuration = 0.0f;


            for (int i = 0; i < actions.Length; ++i) 
            {
                var action = actions[i];
                if (action.Duration > maxDuration)
                {
                    maxDuration = action.Duration;
                }
            }


            Duration = maxDuration;

            Actions = actions;

            for (int i = 0; i < Actions.Length; i++)
            {
                var actionDuration = Actions [i].Duration;
                if (actionDuration < Duration)
                {
                    Actions [i] = new CCSequence (Actions [i], new CCDelayTime (Duration - actionDuration));
                }
            }
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCParallelState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            CCFiniteTimeAction[] rev = new CCFiniteTimeAction[Actions.Length];
            for (int i = 0; i < Actions.Length; i++)
            {
                rev [i] = Actions [i].Reverse ();
            }

            return new CCParallel (rev);
        }

    }

    public class CCParallelState : CCFiniteTimeActionState
    {

        protected CCFiniteTimeAction[] Actions { get; set; }

        protected CCFiniteTimeActionState[] ActionStates { get; set; }

        public CCParallelState (CCParallel action, GameObject target)
            : base (action, target)
        {   
            Actions = action.Actions;
            ActionStates = new CCFiniteTimeActionState[Actions.Length];

            for (int i = 0; i < Actions.Length; i++)
            {
                ActionStates [i] = (CCFiniteTimeActionState)Actions [i].StartAction (target);
            }
        }

        protected internal override void Stop ()
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                ActionStates [i].Stop ();
            }
            base.Stop ();
        }

        public override void Update (float time)
        {
            for (int i = 0; i < Actions.Length; i++)
            {
                ActionStates [i].Update (time);
            }
        }
    }
}