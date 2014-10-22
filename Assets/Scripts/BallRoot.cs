using UnityEngine;
using System.Collections;

public class BallRoot : MonoBehaviour 
{

	public GameObject ballPrefab;

	public int ballNum;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("BallRoot Start");

		PrepareBalls (ballNum);


	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	/**
	 * ボールを生成
	 */
	void PrepareBalls(int number)
	{
		for (var i = 0; i < number; i++)
		{
			Vector3 position = ballPrefab.transform.position;
			position.x = Random.Range(position.x - 1.2f, position.x + 1.2f);
			position.y = Random.Range(position.y - 1.0f, position.y + 1.3f);
			Instantiate(ballPrefab, position, ballPrefab.transform.rotation);
		}
	}
}
