using UnityEngine;

namespace MTUnityAction
{
    public class CCMoveTo : CCMoveBy
    {
        protected Vector3 EndPosition;

        #region Constructors

        public CCMoveTo (float duration, Vector3 position) : base (duration, position)
        {
            EndPosition = position;
        }

        #endregion Constructors

        public Vector3 PositionEnd {
            get { return EndPosition; }
        }

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCMoveToState (this, target);

        }
    }

    public class CCMoveToState : CCMoveByState
    {

        public CCMoveToState (CCMoveTo action, GameObject target)
            : base (action, target)
        { 
			StartPosition = target.transform.position;
			PositionDelta = action.PositionEnd - target.transform.position;
        }

        public override void Update (float time)
        {
            if (Target != null)
            {
//				Vector3 currentPos = Target.transform.position;

                Vector3 newPos = StartPosition + PositionDelta * time;
				Target.transform.position = newPos;
                PreviousPosition = newPos;
            }
        }
    }

}