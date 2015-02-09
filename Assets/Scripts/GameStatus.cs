using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
	private int time = 9999;

	private int score = 20;
	private int highScore;

	private string highScoreKey = "highScore";

	public int Time 
	{
		get { return this.time; }
		set { this.time = value; }
	}
	public int Score 
	{
		get { return this.score; }
		set { this.score = value; } 
	}

	vond Start()
	{
	}

	void Update () 
	{
	}

}
