using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextLabel : MonoBehaviour 
{

	public int currentScore = 0;
	private Text scoreText;

	// Use this for initialization
	void Start () 
	{
		scoreText = this.gameObject.GetComponent<Text> ();
		if (currentScore > 0) {
			scoreText.text = "SCORE:" + currentScore;
		}
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
