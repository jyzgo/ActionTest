using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseElasticOut : CCEaseElastic
    {
        #region Constructors

        public CCEaseElasticOut (CCFiniteTimeAction action) : base (action, 0.3f)
        {
        }

        public CCEaseElasticOut (CCFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCEaseElasticOutState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseElasticIn ((CCFiniteTimeAction)InnerAction.Reverse(), Period);
        }
    }


    #region Action state

    public class CCEaseElasticOutState : CCEaseElasticState
    {
        public CCEaseElasticOutState (CCEaseElasticOut action, GameObject target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.ElasticOut (time, Period));
        }
    }

    #endregion Action state
}