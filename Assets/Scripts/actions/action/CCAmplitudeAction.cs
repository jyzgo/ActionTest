﻿using System;
using UnityEngine;


namespace MTUnityAction
{
    public abstract class CCAmplitudeAction : CCFiniteTimeAction
    {
        public float Amplitude { get; private set; }


        #region Constructors

        public CCAmplitudeAction (float duration, float amplitude = 0) : base (duration)
        {
            Amplitude = amplitude;
        }

        #endregion Constructors
    }


    #region Action state

    public abstract class CCAmplitudeActionState : CCFiniteTimeActionState
    {
        protected float Amplitude { get; private set; }
        protected internal float AmplitudeRate { get; set; }

        public CCAmplitudeActionState (CCAmplitudeAction action, MonoBehaviour target) : base (action, target)
        {
            Amplitude = action.Amplitude;
            AmplitudeRate = 1.0f;
        }
    }

    #endregion Action state
}
