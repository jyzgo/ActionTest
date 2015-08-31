using UnityEngine;

namespace MTUnityAction
{
	public class CCScaleBy : CCScaleTo
	{
		#region Constructors


        public CCScaleBy (float duration, float scale) : base (duration, scale)
		{
		}

		public CCScaleBy (float duration, float scaleX, float scaleY,float scaleZ) : base (duration, scaleX, scaleY,scaleZ)
		{
		}

		#endregion Constructors

		protected internal override MTActionState StartAction(MonoBehaviour target)
		{
			return new CCScaleByState (this, target);

		}

		public override CCFiniteTimeAction Reverse ()
		{
			return new CCScaleBy (Duration, 1 / EndScaleX, 1 / EndScaleY , 1/EndScaleZ);
		}

	}

    public class CCScaleByState : CCScaleToState
	{

		public CCScaleByState (CCScaleTo action, MonoBehaviour target)
			: base (action, target)
		{ 
			DeltaX = StartScaleX * EndScaleX - StartScaleX;
			DeltaY = StartScaleY * EndScaleY - StartScaleY;
			DeltaZ = StartScaleZ * EndScaleZ - StartScaleZ;
		}

	}

}