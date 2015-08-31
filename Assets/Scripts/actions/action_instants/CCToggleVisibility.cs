using UnityEngine;

namespace MTUnityAction
{
    public class CCToggleVisibility : CCActionInstant
    {
        #region Constructors

        public CCToggleVisibility ()
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCToggleVisibilityState (this, target);

        }
    }

    public class CCToggleVisibilityState : CCActionInstantState
    {

        public CCToggleVisibilityState (CCToggleVisibility action, GameObject target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = !render.enabled;
			}
        }

    }

}