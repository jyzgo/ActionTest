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


        protected internal override MTActionState StartAction(GameObject target)
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

        public CCHideState (CCHide action, GameObject target)
            : base (action, target)
        {   
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = true;
			}
        }

    }

}