using System;

using UnityEngine;

namespace CocosSharp
{
    public class CCCallFuncND : CCCallFuncN
    {
        public Action<MonoBehaviour, object> CallFunctionND { get; private set; }
        public object Data { get; private set; }


        #region Constructors

        public CCCallFuncND(Action<MonoBehaviour, object> selector, object d) : base()
        {
            Data = d;
            CallFunctionND = selector;
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCCallFuncNDState (this, target);

        }
    }

    public class CCCallFuncNDState : CCCallFuncState
    {
        protected Action<MonoBehaviour, object> CallFunctionND { get; set; }
        protected object Data { get; set; }

        public CCCallFuncNDState (CCCallFuncND action, MonoBehaviour target)
            : base(action, target)
        {   
            CallFunctionND = action.CallFunctionND;
            Data = action.Data;
        }

        public override void Execute()
        {
            if (null != CallFunctionND)
            {
                CallFunctionND(Target, Data);
            }
        }
    }
}