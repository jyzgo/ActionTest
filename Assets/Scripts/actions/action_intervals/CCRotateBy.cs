using UnityEngine;

namespace MTUnityAction
{
    public class CCRotateBy : CCFiniteTimeAction
    {
        public float AngleX { get; private set; }
        public float AngleY { get; private set; }
		public float AngleZ { get;private set;}


        #region Constructors

		public CCRotateBy (float duration, float deltaAngleX, float deltaAngleY,float deltaAngleZ) : base (duration)
        {
            AngleX = deltaAngleX;
            AngleY = deltaAngleY;
			AngleZ = deltaAngleZ;
        }

		public CCRotateBy (float duration, float deltaAngle) : this (duration, deltaAngle, deltaAngle,deltaAngle)
        {
        }

        #endregion Constructors

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCRotateByState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
			return new CCRotateBy (Duration, -AngleX, -AngleY,-AngleZ);
        }
    }

    public class CCRotateByState : CCFiniteTimeActionState
    {

        protected float AngleX { get; set; }

        protected float AngleY { get; set; }

		protected float AngleZ { get;set;}

        protected float StartAngleX { get; set; }

        protected float StartAngleY { get; set; }

		protected float StartAngleZ { get; set;}

        public CCRotateByState (CCRotateBy action, MonoBehaviour target)
            : base (action, target)
        { 
            AngleX = action.AngleX;
            AngleY = action.AngleY;
			AngleZ = action.AngleZ;

			StartAngleX = target.transform.rotation.x;
			StartAngleY = target.transform.rotation.y;
			StartAngleZ = target.transform.rotation.z;

        }

        public override void Update (float time)
        {
            // XXX: shall I add % 360
            if (Target != null)
            {
				var RotationX = StartAngleX + AngleX * time;
                var RotationY = StartAngleY + AngleY * time;
				var RotationZ = StartAngleZ + AngleZ * time;

				Target.transform.Rotate (new Vector3 (RotationX, RotationY, RotationZ));
            }
        }

    }

}