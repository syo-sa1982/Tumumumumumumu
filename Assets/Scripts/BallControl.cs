using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour 
{
	const string FILE_NAME = "Sprites/TumuYatsu";
	const string SPRITE_NAME = "TumuYatsu_";

	// Use this for initialization
	void Start () 
	{
		string name = SPRITE_NAME + Random.Range(0, 5);
		Sprite sp = GetSprite(FILE_NAME, name);
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
}
