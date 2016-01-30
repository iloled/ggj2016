using UnityEngine;
using System.Collections;

public class MoveNPC : MonoBehaviour {

	[SerializeField]
	Main myMain;

	[SerializeField]
	CameraScript camScript;

	[SerializeField]
	TileScript myTiles;

	// Use this for initialization
	void Start () {
	
	}

	NPC currentNpc;
	int[] movableTiles;
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Mouse0) && camScript.checkHit ()) {

				int pos = camScript.GetPostionTile();
				
				Tile t = Board.tiles[pos];

				if(movableTiles != null && currentNpc != null){
					foreach(var tilesPos in movableTiles)
					{
						if(pos == tilesPos)
						{
							Board.tiles[currentNpc.position].npc = null;
							Board.tiles[tilesPos].npc = currentNpc;
							currentNpc.position = tilesPos;
							currentNpc = null;
							myMain.g.initBoard();

							movableTiles = null;
							myTiles.ClearSprite();
							break;
						}
							else
						{
							Debug.Log ("else");
							movableTiles = null;
							myTiles.ClearSprite();
						}
					}
				}
				else if(t.npc != null)
				{
					currentNpc = t.npc;
					movableTiles = t.npc.listTilesMovement(32).ToArray();
					myTiles.ChangeSprite(movableTiles, 1);
				} 
		}
	}
}
