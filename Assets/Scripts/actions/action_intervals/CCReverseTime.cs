//using System.Diagnostics;

using UnityEngine;

namespace MTUnityAction
{
    public class CCReverseTime : CCFiniteTimeAction
    {
        public CCFiniteTimeAction Other { get; private set; }


        #region Constructors

        public CCReverseTime (CCFiniteTimeAction action) : base (action.Duration)
        {
            Other = action;
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCReverseTimeState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            return Other;
        }
    }

    public class CCReverseTimeState : CCFiniteTimeActionState
    {

        protected CCFiniteTimeAction Other { get; set; }

        protected CCFiniteTimeActionState OtherState { get; set; }

        public CCReverseTimeState (CCReverseTime action, MonoBehaviour target)
            : base (action, target)
        {   
            Other = action.Other;
            OtherState = (CCFiniteTimeActionState)Other.StartAction (target);
        }

        protected internal override void Stop ()
        {
            OtherState.Stop ();
        }

        public override void Update (float time)
        {
            if (Other != null)
            {
                OtherState.Update (1 - time);
            }
        }

    }

}