using UnityEngine;

namespace MTUnityAction
{
    public class CCScaleTo : CCFiniteTimeAction
    {
        public float EndScaleX { get; private set; }
        public float EndScaleY { get; private set; }
		public float EndScaleZ { get; private set; }


        #region Constructors

		public CCScaleTo (float duration, float scale) : this (duration, scale, scale,scale)
        {
        }

		public CCScaleTo (float duration, float scaleX, float scaleY,float scaleZ) : base (duration)
        {
            EndScaleX = scaleX;
            EndScaleY = scaleY;
			EndScaleZ = scaleZ;
        }

        #endregion Constructors

        public override CCFiniteTimeAction Reverse()
        {
            throw new System.NotImplementedException ();
        }

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCScaleToState (this, target);
        }
    }

    public class CCScaleToState : CCFiniteTimeActionState
    {
        protected float DeltaX;
        protected float DeltaY;
		protected float DeltaZ;

        protected float EndScaleX;
        protected float EndScaleY;
		protected float EndScaleZ;

        protected float StartScaleX;
        protected float StartScaleY;
		protected float StartScaleZ;

        public CCScaleToState (CCScaleTo action, GameObject target)
            : base (action, target)
        { 
			StartScaleX = target.transform.localScale.x;
			StartScaleY = target.transform.localScale.y;
			StartScaleZ = target.transform.localScale.z;

            EndScaleX = action.EndScaleX;
            EndScaleY = action.EndScaleY;
			EndScaleZ = action.EndScaleZ;

            DeltaX = EndScaleX - StartScaleX;
            DeltaY = EndScaleY - StartScaleY;
			DeltaZ = EndScaleZ - StartScaleZ;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
               	var ScaleX = StartScaleX + DeltaX * time;
                var ScaleY = StartScaleY + DeltaY * time;
				var ScaleZ = StartScaleZ + DeltaZ * time;
				Target.transform.localScale = new Vector3 (ScaleX, ScaleY, ScaleZ);
            }
        }
    }
}