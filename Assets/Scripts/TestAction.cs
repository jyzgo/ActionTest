using UnityEngine;
using System.Collections;
using MTUnityAction;

public class TestAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MTActionManager.instance.init ();

		var moveTo = new MTMoveTo (12, new Vector3 (10, 10, 10));
		this.gameObject.RunAction (moveTo);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		if (GUILayout.Button ("DDDD")) {
			Destroy (this.gameObject);
		}
	}

	void OnDestroy()
	{
		Debug.Log ("bebe des");
	}
}
