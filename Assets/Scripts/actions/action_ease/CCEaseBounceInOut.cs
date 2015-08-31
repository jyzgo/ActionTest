using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseBounceInOut : CCActionEase
    {
        #region Constructors

        public CCEaseBounceInOut (CCFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCEaseBounceInOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseBounceInOut ((CCFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class CCEaseBounceInOutState : CCActionEaseState
    {
        public CCEaseBounceInOutState (CCEaseBounceInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.BounceInOut (time));
        }
    }

    #endregion Action state
}