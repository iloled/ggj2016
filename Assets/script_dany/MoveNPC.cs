using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MoveNPC : MonoBehaviour {

	[SerializeField]
	Main myMain;

	[SerializeField]
	Text actionPanelText;

	[SerializeField]
	GameObject btMove;

	[SerializeField]
	GameObject btAttack;

	[SerializeField]
	GameObject btConvert;

	[SerializeField]
	CameraScript camScript;

	[SerializeField]
	TileScript myTiles;

	[SerializeField]
	GameObject panelAction;
	// Use this for initialization
	void Start () {
	
	}

	NPC currentNpc;
	Player currentPlayer;
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
							panelAction.SetActive(false);
							break;
						}
							else
						{
							movableTiles = null;
							myTiles.ClearSprite();
							panelAction.SetActive(false);
						}
					}
				}
			else if(t.npc != null &&  myMain.g.currentPlayer == t.npc.party.p)
				{

					currentNpc = t.npc;
					currentPlayer =currentNpc.party.p;
					Debug.Log ("le nom du joueur "+currentPlayer.name);
					currentPlayer.convertWarrior (currentNpc);
					var actions = t.npc.actionList();
					/*
					if ( actions.Contains(MoveAction.))
					{
						btMove.SetActive(true);
					}
					else
					{
						btMove.SetActive(true);
					}
					*/
					/*
					movableTiles = t.npc.listTilesMovement(32).ToArray();
					myTiles.ChangeSprite(movableTiles, 1);
					*/
					panelAction.SetActive(true);
					

				}
		}
	}
}
