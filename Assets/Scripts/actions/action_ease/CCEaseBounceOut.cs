using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseBounceOut : CCActionEase
    {
        #region Constructors

        public CCEaseBounceOut (CCFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCEaseBounceOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseBounceIn ((CCFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class CCEaseBounceOutState : CCActionEaseState
    {
        public CCEaseBounceOutState (CCEaseBounceOut action, MonoBehaviour target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.BounceOut (time));
        }
    }

    #endregion Action state
}