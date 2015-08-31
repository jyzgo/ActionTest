using UnityEngine;
using System.Collections;

namespace MTUnityAction{
public static class MTActionExtension  {


	// public static CCAction runAction(this MonoBehaviour target,CCAction action)
	// {
	// 	CCCCActionManager.instance.instance.addAction(action,target,false);
	// 	return action;
	// }

	// public static CCAction stopAction(this MonoBehaviour target,CCAction action)
	// {
	// 	CCCCActionManager.instance.instance.removeAction(target,action);
	// 	return action;
	// }
    #region Actions

	public static bool IsRunning(this MonoBehaviour target)
	{
		bool isActive = false;
		if (target && target.gameObject && target.gameObject.activeInHierarchy) {
			isActive = true;
		}
		return isActive;
	}

    public static void AddAction(this MonoBehaviour target,CCAction action, bool paused = false)
    {
		if (MTActionManager.instance != null)
				MTActionManager.instance.AddAction(action, target, paused);

    }

	public static void AddActions(this MonoBehaviour target,bool paused, params CCFiniteTimeAction[] actions)
    {
		if (MTActionManager.instance != null)
				MTActionManager.instance.AddAction(new CCSequence(actions), target, paused);

    }

	public static MTActionState Repeat(this MonoBehaviour target, uint times, params CCFiniteTimeAction[] actions)
    {
			return target.RunAction (new CCRepeat (new CCSequence(actions), times));
    }

	public static MTActionState Repeat (this MonoBehaviour target, uint times, CCFiniteTimeAction action)
    {
        return  target.RunAction (new CCRepeat (action, times));
    }

	public static MTActionState RepeatForever(this MonoBehaviour target, params CCFiniteTimeAction[] actions)
    {
        return target.RunAction(new CCRepeatForever (actions));
    }

	public static MTActionState RepeatForever(this MonoBehaviour target, CCFiniteTimeAction action)
    {
        return target.RunAction(new CCRepeatForever (action) { Tag = action.Tag });
    }

	public static MTActionState RunAction(this MonoBehaviour target, CCAction action)
    {
        Debug.Assert(action != null, "Argument must be non-nil");
		

		return  MTActionManager.instance.AddAction(action, target, !target.IsRunning());
    }



    public static MTActionState RunActions(this MonoBehaviour target, params CCFiniteTimeAction[] actions)
    {
        Debug.Assert(actions != null, "Argument must be non-nil");
		Debug.Assert(actions.Length > 0, "Paremeter: actions has length of zero. At least one action must be set to run.");
		

		var action = actions.Length > 1 ? new CCSequence(actions) : actions[0];

			return MTActionManager.instance.AddAction (action, target, !target.IsRunning());
    }




    public static void StopAllActions(this MonoBehaviour target)
    {
        if(MTActionManager.instance != null)
            MTActionManager.instance.RemoveAllActionsFromTarget(target);
    }

    public static void StopAction(this MonoBehaviour target, MTActionState actionState)
    {
        if(MTActionManager.instance != null)
            MTActionManager.instance.RemoveAction(actionState);
    }

	public static void StopAction(this MonoBehaviour target, int tag)
    {
        Debug.Assert(tag != -1, "Invalid tag");
			MTActionManager.instance.RemoveAction(tag, target);
    }

		public static CCAction GetAction(this MonoBehaviour target, int tag)
    {
        Debug.Assert(tag != -1, "Invalid tag");
			return MTActionManager.instance.GetAction(tag, target);
    }

    public static MTActionState GetActionState(this MonoBehaviour target, int tag)
    {
        Debug.Assert(tag != -1, "Invalid tag");
        return MTActionManager.instance.GetActionState(tag, target);
    }

    #endregion Actions

	public static bool getVisible(this MonoBehaviour target)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer> ();
			if (render && render.enabled == true) {
				return true;
			} 
			
		}

		return false;
	}

	public static void setVisible(this MonoBehaviour target ,bool curVis)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer> ();
			if (render) {
				render.enabled = curVis;
			}

		}
	}

	public static float getOpacity(this MonoBehaviour target)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				return render.material.color.a;
			}
			
		}
		return 0f;
	}

	public static void setOpacity(this MonoBehaviour target,float curA)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				var originColor = render.material.color;
				var newColor = new Color (originColor.r,originColor.g,originColor.b,originColor.a);
			
				render.material.color = newColor;
			}
			
		}
	}

	public static Color getColor(this MonoBehaviour target)
	{

		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				var originColor = render.material.color;
				return originColor;
			}
			
		}

		return new Color();
	}

	public static void setColor(this MonoBehaviour target, Color curColor)
	{
		if (target) 
		{
			var render = target.GetComponent<Renderer>();
			if (render && render.material) 
			{
				render.material.color = curColor;
			}
			
		}
	}

}

}