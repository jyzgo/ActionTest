using System;
//using Microsoft.Xna.Framework;



using UnityEngine;

namespace CocosSharp
{
	public class CCEaseSineIn : CCActionEase
	{
		#region Constructors

        public CCEaseSineIn (CCFiniteTimeAction action) : base (action)
		{
		}

		#endregion Constructors


		protected internal override CCActionState StartAction(MonoBehaviour target)
		{
			return new CCEaseSineInState (this, target);
		}

		public override CCFiniteTimeAction Reverse ()
		{
            return new CCEaseSineOut ((CCFiniteTimeAction)InnerAction.Reverse ());
		}
	}


	#region Action state

	public class CCEaseSineInState : CCActionEaseState
	{
		public CCEaseSineInState (CCEaseSineIn action, MonoBehaviour target) : base (action, target)
		{
		}

		public override void Update (float time)
		{
			InnerActionState.Update (CCEaseMath.SineIn (time));
		}
	}

	#endregion Action state
}