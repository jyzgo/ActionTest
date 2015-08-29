using UnityEngine;

namespace CocosSharp
{
    public class CCPlace : CCActionInstant
    {
        public Vector3 Position { get; private set; }


        #region Constructors

        public CCPlace (Vector3 pos)
        {
            Position = pos;
        }

        public CCPlace (int posX, int posY)
        {
            Position = new Vector3 (posX, posY);
        }

        #endregion Constructors

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCPlaceState (this, target);

        }
    }

    public class CCPlaceState : CCActionInstantState
    {

        public CCPlaceState (CCPlace action, MonoBehaviour target)
            : base (action, target)
        { 
			Target.transform.position = action.Position;
        }

    }

}