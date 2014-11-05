using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BallRoot : MonoBehaviour
{
	private const int LAYER_PUZZLE = 8;	// パズルのレイヤー
	private const int MATCH_NUM	= 3;	// 3個以上で消える


	public GameObject ballPrefab;

	private GameObject lastKeepBall; // 最後になぞったボール
	List<GameObject> keepBalls = new List<GameObject>(); // なぞって消す候補

	public int ballNum;

	private bool isTaped = false; // タップ中かどうかの判定

	// カウントダウン用
	int waitingTime = 30;
	private float timer;

	void Start()
	{
		StartCoroutine (PuzzleMake());
	}

	IEnumerator PuzzleMake ()
	{
		PrepareBalls (ballNum);
		while(true){

			yield return new WaitForSeconds(1f);

		}
	}

	// Update is called once per frame
	void Update () 
	{
		Debug.Log (timer);

		if (timer > waitingTime) {
			//Action
			Debug.Log ("時間切れ");

		} else {
			timer += Time.deltaTime;
		}
		// タッチされたとき
		if(Input.GetMouseButtonDown(0)){

			Debug.Log ("GetMouseButtonDown.");
			OnTapDown ();
		}

		// 指を離したとき
		if(Input.GetMouseButtonUp(0)){

			Debug.Log ("GetMouseButtonUp.");
			OnTapUp ();

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
	 * タップ開始
	 */
	private void OnTapDown()
	{
		Vector3 ray_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -20));

		Debug.Log(ray_position);

		isTaped = true;




	}
		
	/**
	 * タップ終了
	 */
	private void OnTapUp()
	{
		Vector3 ray_position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, -20));

		Debug.Log(ray_position);


		isTaped = false;
	}




	/**
	 * チェックメソッド
	 */
	bool IsBall(GameObject obj)
	{
		if (obj == null) {
			return false;
		}
		return (obj.tag == "GreenBall" || obj.tag == "RedBall" || obj.tag == "BlueBall" || obj.tag == "PurpleBall" || obj.tag == "YellowBall");
	}

	bool IsAvailableTag(GameObject obj)
	{
		if (obj == null) {
			return false;
		}
		return (obj.tag == lastKeepBall.tag);
	}

	bool IsAvailableDistance(GameObject obj)
	{
		if (obj == null) {
			return false;
		}
		float distance = Vector3.Distance(obj.transform.position, lastKeepBall.transform.position);
		return distance < 1.0f;
	}



}
