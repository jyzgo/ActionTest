using System;

using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseExponentialInOut : CCActionEase
    {
        #region Constructors

        public CCEaseExponentialInOut (CCFiniteTimeAction action) : base(action)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCEaseExponentialInOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseExponentialInOut ((CCFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class CCEaseExponentialInOutState : CCActionEaseState
    {
        public CCEaseExponentialInOutState (CCEaseExponentialInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.ExponentialInOut (time));
        }
    }

    #endregion Action state
}