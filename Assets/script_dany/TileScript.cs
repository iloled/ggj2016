using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {

	[SerializeField]
	public Transform[] tileTransform;

	[SerializeField]
	SpriteRenderer[] tileSprites;

	[SerializeField]
	Sprite[] spriteList;

	// Use this for initialization
	void Start () {


		int nTile = 0;

	while (nTile < 1024) {
			for(int y = 1; y < 33; ++y)
				for(int x = 1; x < 33; ++x)
				{
					tileTransform[nTile].position = new Vector3(x, y, -0.10f);
					nTile++;
				}
		}
	}

	public Transform GetTileTransform(int id)
	{
		return tileTransform [id];
	}


	
	public void ChangeSprite(int[] spriteID, int color)
	{
		foreach (var elem in spriteID) {
			tileSprites[elem].sprite = spriteList[color];
		}
	}

	public void ClearSprite()
	{
		foreach (var elem in tileSprites) {
			elem.sprite = spriteList[0];
		}
	}

}
