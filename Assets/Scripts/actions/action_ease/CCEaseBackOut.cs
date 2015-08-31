using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseBackOut : CCActionEase
    {
        #region Constructors

        public CCEaseBackOut (CCFiniteTimeAction action) : base (action)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCEaseBackOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseBackIn ((CCFiniteTimeAction)InnerAction.Reverse ());
        }
    }


    #region Action state

    public class CCEaseBackOutState : CCActionEaseState
    {
        public CCEaseBackOutState (CCEaseBackOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.BackOut (time));
        }
    }

    #endregion Action state
}