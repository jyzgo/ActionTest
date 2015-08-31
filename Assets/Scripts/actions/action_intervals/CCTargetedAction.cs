using UnityEngine;

namespace MTUnityAction
{
    public class CCTargetedAction : CCFiniteTimeAction
    {
        public CCFiniteTimeAction TargetedAction { get; private set; }
        public GameObject ForcedTarget { get; private set; }


        #region Constructors

        public CCTargetedAction (GameObject target, CCFiniteTimeAction action) : base (action.Duration)
        {
            ForcedTarget = target;
            TargetedAction = action;
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCTargetedActionState (this, target);
        }

        public override CCFiniteTimeAction Reverse()
        {
            return new CCTargetedAction (ForcedTarget, TargetedAction.Reverse ());
        }
    }

    public class CCTargetedActionState : CCFiniteTimeActionState
    {
        protected CCFiniteTimeAction TargetedAction { get; set; }

        protected CCFiniteTimeActionState ActionState { get; set; }

        protected GameObject ForcedTarget { get; set; }

        public CCTargetedActionState (CCTargetedAction action, GameObject target)
            : base (action, target)
        {   
            ForcedTarget = action.ForcedTarget;
            TargetedAction = action.TargetedAction;

            ActionState = (CCFiniteTimeActionState)TargetedAction.StartAction (ForcedTarget);
        }

        protected internal override void Stop ()
        {
            ActionState.Stop ();
        }

        public override void Update (float time)
        {
            ActionState.Update (time);
        }


    }

}