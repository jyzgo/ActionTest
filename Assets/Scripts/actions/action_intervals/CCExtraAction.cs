using System;
//using System.Diagnostics;

using UnityEngine;

namespace CocosSharp
{
    // Extra action for making a CCSequence or CCSpawn when only adding one action to it.
    internal class CCExtraAction : CCFiniteTimeAction
    {
        public override CCFiniteTimeAction Reverse ()
        {
            return new CCExtraAction ();
        }

        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCExtraActionState (this, target);

        }

        #region Action State

        public class CCExtraActionState : CCFiniteTimeActionState
        {

            public CCExtraActionState (CCExtraAction action, MonoBehaviour target)
                : base (action, target)
            {
            }

            protected internal override void Step (float dt)
            {
            }

            public override void Update (float time)
            {
            }
        }

        #endregion Action State
    }
}