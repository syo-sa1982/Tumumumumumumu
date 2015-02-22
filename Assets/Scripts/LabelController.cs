using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class LabelController : MonoBehaviour 
{
	GameStatus gameStatus = new GameStatus ();

	private Text statusText;

	// Use this for initialization
	void Start () 
	{
		statusText = this.gameObject.GetComponent<Text> ();

		switch(this.gameObject.tag) {
		case "Score":
			statusText.text = "SCORE:" + gameStatus.Score;
			break;
		case "Timer":
			statusText.text = "TIME:" + gameStatus.Time;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Update from LabelController");

//		switch(this.gameObject.tag) {
//		case "Timer":
//			gameStatus.Time = gameStatus.Time - 1;
//			statusText.text = "TIME:" + gameStatus.Time;
//			break;
//		}

	}
}
