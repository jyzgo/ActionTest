using System;

using UnityEngine;

namespace CocosSharp
{
    public class CCFadeTo : CCFiniteTimeAction
    {
        public byte ToOpacity { get; private set; }


        #region Constructors

        public CCFadeTo (float duration, byte opacity) : base (duration)
        {
            ToOpacity = opacity;
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCFadeToState (this, target);

        }

        public override CCFiniteTimeAction Reverse()
        {
            throw new NotImplementedException();
        }
    }

    public class CCFadeToState : CCFiniteTimeActionState
    {
		protected float FromOpacity { get; set; }

		protected float ToOpacity { get; set; }

        public CCFadeToState (CCFadeTo action, MonoBehaviour target)
            : base (action, target)
        {              
            ToOpacity = action.ToOpacity;

            var pRGBAProtocol = target;
            if (pRGBAProtocol != null)
            {
				FromOpacity = pRGBAProtocol.getOpacity();
            }
        }

        public override void Update (float time)
        {
            var pRGBAProtocol = Target;
            if (pRGBAProtocol != null)
            {
				pRGBAProtocol.setOpacity (FromOpacity + (ToOpacity - FromOpacity) * time);
            }
        }
    }


}