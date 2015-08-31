using UnityEngine;

namespace MTUnityAction
{
    public class CCFadeOut : CCFiniteTimeAction
    {
        #region Constructors

        public CCFadeOut (float durtaion) : base (durtaion)
        {
        }

        #endregion Constructors

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCFadeOutState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCFadeIn (Duration);
        }
    }

    public class CCFadeOutState : CCFiniteTimeActionState
    {

        public CCFadeOutState (CCFadeOut action, GameObject target)
            : base (action, target)
        {
        }

        public override void Update (float time)
        {
            var pRGBAProtocol = Target;
            if (pRGBAProtocol != null)
            {
				pRGBAProtocol.setOpacity(1 - time);
            }
        }

    }

}