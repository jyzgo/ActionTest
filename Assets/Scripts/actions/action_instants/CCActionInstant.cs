using UnityEngine;

namespace CocosSharp
{
    public class CCActionInstant : CCFiniteTimeAction
    {

        #region Constructors

        protected CCActionInstant ()
        {
        }

        #endregion Constructors

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCActionInstantState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCActionInstant ();
        }
    }

    public class CCActionInstantState : CCFiniteTimeActionState
    {

        public CCActionInstantState (CCActionInstant action, MonoBehaviour target)
            : base (action, target)
        {
        }

        public override bool IsDone 
        {
            get { return true; }
        }

        protected internal override void Step (float dt)
        {
            Update (1);
        }

        public override void Update (float time)
        {
            // ignore
        }
    }

}