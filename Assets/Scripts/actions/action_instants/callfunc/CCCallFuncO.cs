using System;

using UnityEngine;

namespace MTUnityAction
{
    public class CCCallFuncO : CCCallFunc
    {
        public Action<object> CallFunctionO { get; private set; }
        public object Object { get; private set; }

        #region Constructors

        public CCCallFuncO()
        {
            Object = null;
            CallFunctionO = null;
        }

        public CCCallFuncO(Action<object> selector, object pObject) : this()
        {
            Object = pObject;
            CallFunctionO = selector;
        }

        #endregion Constructors

        protected internal override MTActionState StartAction(MonoBehaviour target)
        {
            return new CCCallFuncOState (this, target);

        }

    }

    public class CCCallFuncOState : CCCallFuncState
    {
        protected Action<object> CallFunctionO { get; set; }
        protected object Object { get; set; }

        public CCCallFuncOState (CCCallFuncO action, MonoBehaviour target)
            : base(action, target)
        {   
            CallFunctionO = action.CallFunctionO;
            Object = action.Object;
        }

        public override void Execute()
        {
            if (null != CallFunctionO)
            {
                CallFunctionO(Object);
            }
        }
    }
}