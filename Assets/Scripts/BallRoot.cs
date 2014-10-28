﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallRoot : MonoBehaviour,ITap
{

	public GameObject ballPrefab;

	private GameObject lastKeepBall;
	List<GameObject> keepBalls = new List<GameObject>();

	public int ballNum;

	IEnumerator Start ()
	{
		PrepareBalls (ballNum);
		while(true){

			if (Input.GetMouseButton (0)) {
				Debug.Log ("Pressed left click.");
			}
			yield return new WaitForSeconds(3.0f);

			PrepareBalls (3);
		}
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("GetMouseButtonDown");
		}
	}

	/**
	 * ボールを生成
	 */
	void PrepareBalls(int number)
	{
		if (number <= 0) {
			return;
		}

		Vector3 position = ballPrefab.transform.position;
		position.x = Random.Range(position.x - 1.2f, position.x + 1.2f);
		position.y = Random.Range(position.y - 1.0f, position.y + 1.3f);
		Instantiate(ballPrefab, position, ballPrefab.transform.rotation);

		// numberが０になるまで再帰
		--number;
		PrepareBalls (number);
	}

	/**
	 * インターフェイスからの実装
	 */
	public void TapDown(ref RaycastHit hit)
	{
	}
	public void TapUp(ref RaycastHit hit)
	{
	}


	bool IsBall()
	{
		return false;
	}
}
