using System;
using UnityEngine; 


namespace MTUnityAction
{
    public class CCEaseSineInOut : CCActionEase
    {
        #region Constructors

        public CCEaseSineInOut (CCFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(MonoBehaviour target)
        {
            return new CCEaseSineInOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseSineInOut ((CCFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class CCEaseSineInOutState : CCActionEaseState
    {
        public CCEaseSineInOutState (CCEaseSineInOut action, MonoBehaviour target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.SineInOut (time));
        }
    }

    #endregion Action state
}