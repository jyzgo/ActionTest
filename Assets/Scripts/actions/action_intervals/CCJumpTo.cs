using UnityEngine;

namespace MTUnityAction
{
    public class CCJumpTo : CCJumpBy
    {
        #region Constructors

        public CCJumpTo (float duration, Vector3 position, float height, uint jumps) 
            : base (duration, position, height, jumps)
        {
        }

        #endregion Constructors

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCJumpToState (this, target);

        }

    }

    public class CCJumpToState : CCJumpByState
    {

        public CCJumpToState (CCJumpBy action, MonoBehaviour target)
            : base (action, target)
        { 
			Delta = new Vector3 (Delta.x - StartPosition.x, Delta.y - StartPosition.y,Delta.z - StartPosition.z);
        }
    }

}