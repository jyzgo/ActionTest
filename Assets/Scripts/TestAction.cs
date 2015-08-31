using UnityEngine;
using System.Collections;
using MTUnityAction;

public class TestAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
		CCActionManager.instance.init ();

		var moveTo = new CCMoveTo (3, new Vector3 (10, 10, 10));
		this.RunAction (moveTo);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
