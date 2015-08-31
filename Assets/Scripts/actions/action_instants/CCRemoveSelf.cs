using System;
using System.Collections.Generic;

using UnityEngine;

namespace MTUnityAction
{
    public class CCRemoveSelf : CCActionInstant
    {
        public bool IsNeedCleanUp { get; private set; }

        #region Constructors

        public CCRemoveSelf ()
            : this (true)
        {
        }

        public CCRemoveSelf (bool isNeedCleanUp)
        {
            IsNeedCleanUp = isNeedCleanUp;
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCRemoveSelfState (this, target);

        }


        public override CCFiniteTimeAction Reverse ()
        {
            return new CCRemoveSelf (IsNeedCleanUp);
        }
    }

    public class CCRemoveSelfState : CCActionInstantState
    {
        protected bool IsNeedCleanUp { get; set; }

        public CCRemoveSelfState (CCRemoveSelf action, GameObject target)
            : base (action, target)
        {   
            IsNeedCleanUp = action.IsNeedCleanUp;
        }

        public override void Update (float time)
        {
            if (Target && Target.gameObject) 
            {
                UnityEngine.Object.Destroy(Target.gameObject);
            }
        }

    }

}