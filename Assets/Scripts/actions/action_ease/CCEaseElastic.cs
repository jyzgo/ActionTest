using UnityEngine;

namespace MTUnityAction
{
    public class CCEaseElastic : CCActionEase
    {
        public float Period { get; private set; }


        #region Constructors

        public CCEaseElastic (CCFiniteTimeAction action, float period) : base (action)
        {
            Period = period;
        }

        public CCEaseElastic (CCFiniteTimeAction action) : this (action, 0.3f)
        {
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCEaseElasticState (this, target);
        }

        public override CCFiniteTimeAction Reverse ()
        {
            return null;
        }
    }


    #region Action state

    public class CCEaseElasticState : CCActionEaseState
    {
        protected float Period { get; private set; }

        public CCEaseElasticState (CCEaseElastic action, GameObject target) : base (action, target)
        {
            Period = action.Period;
        }
    }

    #endregion Action state
}