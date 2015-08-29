using UnityEngine;
using System.Collections;

public static class ActionExtension  {
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
