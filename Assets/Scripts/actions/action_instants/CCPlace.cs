using UnityEngine;

namespace MTUnityAction
{
    public class CCPlace : CCActionInstant
    {
        public Vector3 Position { get; private set; }


        #region Constructors

        public CCPlace (Vector3 pos)
        {
            Position = pos;
        }

        public CCPlace (int posX, int posY , int posZ)
        {
            Position = new Vector3 (posX, posY,posZ);
        }

        #endregion Constructors

        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCPlaceState (this, target);

        }
    }

    public class CCPlaceState : CCActionInstantState
    {

        public CCPlaceState (CCPlace action, GameObject target)
            : base (action, target)
        { 
			Target.transform.position = action.Position;
        }

    }

}