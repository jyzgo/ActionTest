using UnityEngine;

namespace MTUnityAction
{
    public class CCFadeIn : CCFiniteTimeAction
    {
        #region Constructors

        public CCFadeIn (float durataion) : base (durataion)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(MonoBehaviour target)
        {
            return new CCFadeInState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCFadeOut (Duration);
        }
    }

    public class CCFadeInState : CCFiniteTimeActionState
    {

        protected uint Times { get; set; }

        protected bool OriginalState { get; set; }

        public CCFadeInState (CCFadeIn action, MonoBehaviour target)
            : base (action, target)
        {
        }

        public override void Update (float time)
        {
            var pRGBAProtocol = Target;
            if (pRGBAProtocol != null)
            {
//                pRGBAProtocol.Opacity = (byte)(255 * time);
				pRGBAProtocol.setOpacity(time);
            }
        }
    }

}