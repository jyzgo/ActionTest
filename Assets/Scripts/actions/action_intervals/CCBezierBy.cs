using System;

using UnityEngine;

namespace MTUnityAction
{
    public class CCBezierBy : CCFiniteTimeAction
    {
        public CCBezierConfig BezierConfig { get; private set; }


        #region Constructors

        public CCBezierBy (float t, CCBezierConfig config) : base (t)
        {
            BezierConfig = config;
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCBezierByState (this, target);

        }

        public override CCFiniteTimeAction Reverse ()
        {
            CCBezierConfig r;

            r.EndPosition = -BezierConfig.EndPosition;
            r.ControlPoint1 = BezierConfig.ControlPoint2 + -BezierConfig.EndPosition;
            r.ControlPoint2 = BezierConfig.ControlPoint1 + -BezierConfig.EndPosition;

            var action = new CCBezierBy (Duration, r);
            return action;
        }
    }

    public class CCBezierByState : CCFiniteTimeActionState
    {
        protected CCBezierConfig BezierConfig { get; set; }

        protected Vector3 StartPosition { get; set; }

        protected Vector3 PreviousPosition { get; set; }


        public CCBezierByState (CCBezierBy action, GameObject target)
            : base (action, target)
        { 
            BezierConfig = action.BezierConfig;
			PreviousPosition = StartPosition = target.transform.position;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
                float xa = 0;
                float xb = BezierConfig.ControlPoint1.x;
                float xc = BezierConfig.ControlPoint2.x;
                float xd = BezierConfig.EndPosition.x;

                float ya = 0;
                float yb = BezierConfig.ControlPoint1.y;
                float yc = BezierConfig.ControlPoint2.y;
                float yd = BezierConfig.EndPosition.y;

                float za = 0;
                float zb = BezierConfig.ControlPoint1.z;
                float zc = BezierConfig.ControlPoint2.z;
                float zd = BezierConfig.EndPosition.z;

                float x = CCSplineMath.CubicBezier (xa, xb, xc, xd, time);
                float y = CCSplineMath.CubicBezier (ya, yb, yc, yd, time);
                float z = CCSplineMath.CubicBezier (za, zb, zc, zd, time);

				Vector3 currentPos = Target.transform.position;
                Vector3 diff = currentPos - PreviousPosition;
                StartPosition = StartPosition + diff;

                Vector3 newPos = StartPosition + new Vector3 (x, y,z);
				Target.transform.position = newPos;

                PreviousPosition = newPos;
            }
        }

    }

    public struct CCBezierConfig
    {
        public Vector3 ControlPoint1;
        public Vector3 ControlPoint2;
        public Vector3 EndPosition;
    }
}