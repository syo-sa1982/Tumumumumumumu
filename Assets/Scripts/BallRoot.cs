using UnityEngine;
using System.Collections;

public class BallRoot : MonoBehaviour 
{

	public GameObject ballSpawnPoint;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	void PrepareBalls(int number)
	{
		for (var i = 0; i < number; i++)
		{
			GameObject ball = ChoosePrehab();
			Vector3 position = ballSpawnPoint.transform.position;
			position.x = Random.Range(position.x - 1.2f, position.x + 1.2f);
			position.y = Random.Range(position.y - 1.0f, position.y + 1.3f);
			Instantiate(ball, position, ball.transform.rotation);
		}
	}
}
