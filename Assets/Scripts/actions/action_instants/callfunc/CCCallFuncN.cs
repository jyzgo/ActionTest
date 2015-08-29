using System;

using UnityEngine;

namespace CocosSharp
{
    public class CCCallFuncN : CCCallFunc
    {
        public Action<MonoBehaviour> CallFunctionN { get; private set; }

        #region Constructors

        public CCCallFuncN() : base()
        {
        }

        public CCCallFuncN(Action<MonoBehaviour> selector) : base()
        {
            CallFunctionN = selector;
        }

        #endregion Constructors


        protected internal override CCActionState StartAction(MonoBehaviour target)
        {
            return new CCCallFuncNState (this, target);

        }

    }

    public class CCCallFuncNState : CCCallFuncState
    {

        protected Action<MonoBehaviour> CallFunctionN { get; set; }

        public CCCallFuncNState (CCCallFuncN action, MonoBehaviour target)
            : base(action, target)
        {   
            CallFunctionN = action.CallFunctionN;
        }

        public override void Execute()
        {
            if (null != CallFunctionN)
            {
                CallFunctionN(Target);
            }
            //if (m_nScriptHandler) {
            //    CCScriptEngineManager::sharedManager()->getScriptEngine()->executeFunctionWithobject(m_nScriptHandler, m_pTarget, "MonoBehaviour");
            //}
        }

    }
}