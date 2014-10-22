using UnityEngine;
using System.Collections;


public class Ball
{
	public enum COLOR
	{
		WHITE = 0,
		BULE,
		YELLOW,
		GREEN,
		ORANGE,
		RED,
		NUM,
	};
}

public class BallControl : MonoBehaviour 
{
	private Ball.COLOR color;

	void Awake()
	{
		int color_index = (int)Random.Range (0.0f,6.0f);
		setColor ((Ball.COLOR)color_index);
	}

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void setColor(Ball.COLOR color) 
	{
		this.color = color;

		Color color_value;

		switch(this.color) 
		{
		default:
		case Ball.COLOR.BULE:
			color_value = Color.blue;
			break;
		case Ball.COLOR.YELLOW:
			color_value = Color.yellow;
			break;
		case Ball.COLOR.GREEN:
			color_value = Color.green;
			break;
		case Ball.COLOR.ORANGE:
			color_value = new Color(1.0f, 0.46f, 0.0f);
			break;
		case Ball.COLOR.RED:
			color_value = Color.red;
			break;
		}

		this.renderer.material.color = color_value;
	}
}
