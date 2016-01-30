using UnityEngine;
using System.Collections;

public class MoveNPC : MonoBehaviour {

	
	[SerializeField]
	CameraScript camScript;

	[SerializeField]
	TileScript myTiles;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Mouse0) && camScript.checkHit ()) {

				int pos = camScript.GetPostionTile();
				
				Tile t = Board.tiles[pos];

				if(t.npc != null)
				{
					myTiles.ClearSprite();
					myTiles.ChangeSprite(t.npc.listTilesMovement(32).ToArray(), 1);

				}
			else
			{
				myTiles.ClearSprite();
			}
				
				
		}
	}
}
