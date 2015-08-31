using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseBackInOut : CCActionEase
    {
        #region Constructors

        public CCEaseBackInOut(CCFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCEaseBackInOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse()
        {
            return new CCEaseBackInOut ((CCFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class CCEaseBackInOutState : CCActionEaseState
    {
        public CCEaseBackInOutState (CCEaseBackInOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.BackInOut (time));
        }
    }

    #endregion Action state
}