using UnityEngine;

namespace CocosSharp
{
    public class CCToggleVisibility : CCActionInstant
    {
        #region Constructors

        public CCToggleVisibility ()
        {
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCToggleVisibilityState (this, target);

        }
    }

    public class CCToggleVisibilityState : CCActionInstantState
    {

        public CCToggleVisibilityState (CCToggleVisibility action, MonoBehaviour target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = !render.enabled;
			}
        }

    }

}