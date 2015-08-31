using System;

using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseSineOut : CCActionEase
    {
        #region Constructors

        public CCEaseSineOut (CCFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCEaseSineOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseSineIn ((CCFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class CCEaseSineOutState : CCActionEaseState
    {
        public CCEaseSineOutState (CCEaseSineOut action, MonoBehaviour target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.SineOut (time));
        }
    }

    #endregion Action state
}