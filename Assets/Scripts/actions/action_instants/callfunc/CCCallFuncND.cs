using System;

using UnityEngine;

namespace MTUnityAction
{
    public class CCCallFuncND : CCCallFuncN
    {
        public Action<GameObject, object> CallFunctionND { get; private set; }
        public object Data { get; private set; }


        #region Constructors

        public CCCallFuncND(Action<GameObject, object> selector, object d) : base()
        {
            Data = d;
            CallFunctionND = selector;
        }

        #endregion Constructors


        protected internal override MTActionState StartAction(GameObject target)
        {
            return new CCCallFuncNDState (this, target);

        }
    }

    public class CCCallFuncNDState : CCCallFuncState
    {
        protected Action<GameObject, object> CallFunctionND { get; set; }
        protected object Data { get; set; }

        public CCCallFuncNDState (CCCallFuncND action, GameObject target)
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