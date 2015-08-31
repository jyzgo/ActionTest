using UnityEngine;

namespace MTUnityAction
{
    public class CCDelayTime : CCFiniteTimeAction
    {
        #region Constructors

        public CCDelayTime (float duration) : base (duration)
        {
        }

        #endregion Constructors

        protected internal override MTActionState StartAction(MonoBehaviour target)
        {
            return new CCDelayTimeState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCDelayTime (Duration);
        }
    }

    public class CCDelayTimeState : CCFiniteTimeActionState
    {

        public CCDelayTimeState (CCDelayTime action, MonoBehaviour target)
            : base (action, target)
        {
        }

        public override void Update (float time)
        {
        }

    }
}