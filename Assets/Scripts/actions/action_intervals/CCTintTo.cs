using UnityEngine;

namespace CocosSharp
{
    public class CCTintTo : CCFiniteTimeAction
    {
        public Color ColorTo { get; private set; }


        #region Constructors

        public CCTintTo (float duration, byte red, byte green, byte blue) : base (duration)
        {
            ColorTo = new Color (red, green, blue);
        }

        #endregion Constructors

        public override CCFiniteTimeAction Reverse()
        {
            throw new System.NotImplementedException ();
        }

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCTintToState (this, target);
        }
    }

    public class CCTintToState : CCFiniteTimeActionState
    {
        protected Color ColorFrom { get; set; }

        protected Color ColorTo { get; set; }

        public CCTintToState (CCTintTo action, MonoBehaviour target)
            : base (action, target)
        {   
            ColorTo = action.ColorTo;
            var protocol = Target;
            if (protocol != null)
            {
				ColorFrom = protocol.getColor();
            }
        }

        public override void Update (float time)
        {
            var protocol = Target;
            if (protocol != null)
            {
                protocol.Color = new Color ((byte)(ColorFrom.R + (ColorTo.R - ColorFrom.R) * time),
                    (byte)(ColorFrom.G + (ColorTo.G - ColorFrom.G) * time),
                    (byte)(ColorFrom.B + (ColorTo.B - ColorFrom.B) * time));
            }
        }

    }

}