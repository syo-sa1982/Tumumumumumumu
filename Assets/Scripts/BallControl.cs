using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour 
{
	const string FILE_NAME = "Sprites/TumuYatsu";
	const string SPRITE_NAME = "TumuYatsu_";


	[SerializeField]
	private int spriteID = 0;

	public int PuzzleID {
		get
		{
			return spriteID; 
		}
		private set {
			spriteID = value;
		}
	}

	// Use this for initialization
	void Start () 
	{
		this.PuzzleID = Random.Range (0, 5);
		string spriteName = SPRITE_NAME + this.PuzzleID;

		Debug.Log (this.PuzzleID);
		Debug.Log (spriteName);

		Sprite sp = GetSprite(FILE_NAME, spriteName);
		SpriteRenderer sr = GetComponent<SpriteRenderer>();
		sr.sprite = sp;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	public Sprite GetSprite(string fileName, string spriteName)
	{
		Sprite[] sprites = Resources.LoadAll<Sprite>(fileName);
		return System.Array.Find<Sprite>(sprites, (sprite) => sprite.name.Equals(spriteName));
	}

	void TappedDestroy()
	{
		Debug.Log ("TappedDestroy");
		Destroy(gameObject);
	}
}
