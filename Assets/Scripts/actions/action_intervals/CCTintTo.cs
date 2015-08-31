using UnityEngine;

namespace MTUnityAction
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

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCTintToState (this, target);
        }
    }

    public class CCTintToState : CCFiniteTimeActionState
    {
        protected Color ColorFrom { get; set; }

        protected Color ColorTo { get; set; }

        public CCTintToState (CCTintTo action, GameObject target)
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
				
				protocol.GetComponent<Renderer> ().material.color = new Color ((ColorFrom.r + (ColorTo.r - ColorFrom.r) * time),
                    (ColorFrom.g + (ColorTo.g - ColorFrom.g) * time),
                    (ColorFrom.b + (ColorTo.b - ColorFrom.b) * time));
            }
        }

    }

}