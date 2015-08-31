using UnityEngine;

namespace MTUnityAction
{
    public class CCShow : CCActionInstant
    {
        #region Constructors

        public CCShow ()
        {
        }

        #endregion Constructors

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCShowState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            return (new CCHide ());
        }

    }

    public class CCShowState : CCActionInstantState
    {

        public CCShowState (CCShow action, MonoBehaviour target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = true;
			}
        }

    }

}