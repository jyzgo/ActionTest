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

        protected internal override CCActionState StartAction(MonoBehaviour target)
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

        public CCFadeOutState (CCFadeOut action, MonoBehaviour target)
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