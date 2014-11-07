using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour 
{
	const string FILE_NAME = "Sprites/TumuYatsu";
	const string SPRITE_NAME = "TumuYatsu_";


	[SerializeField]
	private int id = 0;

	public int PuzzleID {
		get
		{
			return id; 
		}
		private set {
			id = value;
		}
	}

	// Use this for initialization
	void Start () 
	{
		string spriteName = SPRITE_NAME + Random.Range(0, 5);


		// タグにも入れとく
		print(gameObject.tag);
//		gameObject.tag = spriteName;

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
		Destroy(gameObject);
	}
}
