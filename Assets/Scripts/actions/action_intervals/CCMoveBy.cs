using UnityEngine;

namespace CocosSharp
{
    public class CCMoveBy : CCFiniteTimeAction
    {
        #region Constructors

        public CCMoveBy (float duration, Vector3 position) : base (duration)
        {
            PositionDelta = position;
        }

        #endregion Constructors

        public Vector3 PositionDelta { get; private set; }

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCMoveByState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCMoveBy (Duration, new Vector3 (-PositionDelta.x, -PositionDelta.y));
        }
    }

    public class CCMoveByState : CCFiniteTimeActionState
    {
        protected Vector3 PositionDelta;
        protected Vector3 EndPosition;
        protected Vector3 StartPosition;
        protected Vector3 PreviousPosition;

        public CCMoveByState (CCMoveBy action, MonoBehaviour target)
            : base (action, target)
        { 
			PositionDelta = action.PositionDelta;
			PreviousPosition = StartPosition = target.transform.position;
        }

        public override void Update (float time)
        {
            if (Target == null)
                return;

			var currentPos = Target.transform.position;
            var diff = currentPos - PreviousPosition;
            StartPosition = StartPosition + diff;
            Vector3 newPos = StartPosition + PositionDelta * time;
			Target.transform.position = newPos;
            PreviousPosition = newPos;
        }
    }

}