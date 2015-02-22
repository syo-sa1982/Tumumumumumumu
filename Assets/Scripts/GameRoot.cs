using UnityEngine;
using System.Collections;

public class GameRoot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Now scene is " + Application.loadedLevelName);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0)){
		}
		if(Input.GetMouseButton(0)){

		}
		if(Input.GetMouseButtonUp(0)){
			Debug.Log ("タップした");
			Application.LoadLevel ("Stage");
		}
	}
}
