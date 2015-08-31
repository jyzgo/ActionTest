using UnityEngine;

namespace MTUnityAction
{
    public class CCHide : CCActionInstant
    {
        #region Constructors

        public CCHide ()
        {
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCHideState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            return (new CCShow ());
        }

    }

    public class CCHideState : CCActionInstantState
    {

        public CCHideState (CCHide action, MonoBehaviour target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = true;
			}
        }

    }

}