using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseElasticIn : CCEaseElastic
    {
        #region Constructors

        public CCEaseElasticIn (CCFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        public CCEaseElasticIn (CCFiniteTimeAction action, float period) : base (action, period)
        {
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCEaseElasticInState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return new CCEaseElasticOut ((CCFiniteTimeAction)InnerAction.Reverse (), Period);
        }
    }


    #region Action state

    public class CCEaseElasticInState : CCEaseElasticState
    {
        public CCEaseElasticInState (CCEaseElasticIn action, MonoBehaviour target) : base (action, target)
        {
        }

        public override void Update (float time)
        {
            InnerActionState.Update (CCEaseMath.ElasticIn (time, Period));
        }
    }

    #endregion Action state
}