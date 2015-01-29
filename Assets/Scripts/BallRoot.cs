using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BallRoot : MonoBehaviour
{
	private const int LAYER_PUZZLE = 8;	// パズルのレイヤー
	private const int MATCH_NUM	= 3;	// 3個以上で消える

	public float distance = 10; // Rayの届く距離

	private int score = 0;
	public GameObject scoreText;

	public GameObject ballPrefab;

	private GameObject lastKeepBall; // 最後になぞったボール
	List<GameObject> keepBalls = new List<GameObject>(); // なぞって消す候補

	public int ballNum;

	private bool isTaped = false; // タップ中かどうかの判定

	[SerializeField]
	private LineRenderer deleteLine;

	// カウントダウン用
	int waitingTime = 30;
	private float timer;

	void Start()
	{
		scoreText.GetComponent<Text> ().text = score.ToString();
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
//		Debug.Log (timer);

		if (timer > waitingTime) {
			//Action
//			Debug.Log ("時間切れ");

		} else {
			timer += Time.deltaTime;
		}

		if(Input.GetMouseButtonDown(0)){
			OnTapDown();
		}
		if(Input.GetMouseButton(0)){
			OnTapDrag();
		}
		if(Input.GetMouseButtonUp(0)){
			OnTapUp();
		}

		DrawLine ();
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

		// Rayのレイヤー対象設定
		int layerMask = 1 << LAYER_PUZZLE;

		Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

		if (aCollider2d) {
			isTaped = true;

			RaycastHit2D hit = Physics2D.Raycast (aTapPoint, -Vector2.up);

			AddHitObject (hit);
		}
	}
	/**
	 * タップドラッグ中
	 */
	private void OnTapDrag()
	{
		if (!isTaped) {return;}

		Vector3 aTapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Collider2D aCollider2d = Physics2D.OverlapPoint(aTapPoint);

		if (aCollider2d) {

//			GameObject obj = aCollider2d.transform.gameObject;
			RaycastHit2D hit = Physics2D.Raycast (aTapPoint, -Vector2.up);

			AddHitObject (hit);
		}

	}

	/**
	 * タップ終了
	 */
	private void OnTapUp()
	{
		// ラインレンダラー消します
		deleteLine.SetVertexCount (0);

		if (keepBalls.Count >= 3)
		{
			for (int i = 0; i < keepBalls.Count; i++)
			{
				keepBalls[i].SendMessage("TappedDestroy");
			}
			score += (keepBalls.Count * 100);
			Debug.Log (score);
			scoreText.GetComponent<Text> ().text = score.ToString();
			PrepareBalls(keepBalls.Count);
		}
		isTaped = false;
		lastKeepBall = null;
		keepBalls.Clear();
	}

	private void DrawLine()
	{
		// パズルの数だけまわす
		for(int i = 0; i < keepBalls.Count; i++)
		{
			// 子の座標を取得
			Vector3 puzzle_position = keepBalls[i].transform.position;

			// 座標をそろえていく
			deleteLine.SetPosition (i,puzzle_position + (Vector3.forward * -1));
			//	// NOTE: 手前に出すためちょっと前にだす

		}
	}

	public void AddHitObject (RaycastHit2D hit)
	{
		if (hit) {
			GameObject hitObject = hit.collider.gameObject;
			if (IsBall(hitObject) 
				&& (lastKeepBall == null 
					|| (lastKeepBall != hitObject && IsAvailableTag(hitObject) && IsAvailableDistance(hitObject))))
			{
				lastKeepBall = hitObject;

				// ラインを伸ばす
				deleteLine.SetVertexCount (keepBalls.Count + 1);	// 要素数を揃える
				// 座標を更新
				deleteLine.SetPosition (
					keepBalls.Count,
					hitObject.transform.position + (Vector3.forward * -1)	// NOTE: 手前にだす為、まえにちょっと出す
				);

				keepBalls.Add(hitObject);
			}
		}
	}

	/**
	 * チェックメソッド
	 */
	bool IsBall(GameObject obj)
	{
		if (obj == null) {
			return false;
		}
		int puzzleID = obj.GetComponent<BallControl> ().PuzzleID;
		return (puzzleID >= 0 && puzzleID < 5 );
	}

	bool IsAvailableTag(GameObject obj)
	{
		if (obj == null) {
			return false;
		}
		int puzzleID = obj.GetComponent<BallControl> ().PuzzleID;
		int lastKeepBallID = lastKeepBall.GetComponent<BallControl> ().PuzzleID;
		return (puzzleID == lastKeepBallID);
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
