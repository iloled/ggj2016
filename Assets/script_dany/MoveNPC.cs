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

	public NPC selectedNpc;

	NPC currentNpc;
	Player currentPlayer;
	int[] movableTiles;
	bool guiClicked = false;


	public void startMovingNpc()
	{
		guiClicked = true;

		if (selectedNpc != null) {
			movableTiles = selectedNpc.listTilesMovement(32).ToArray();
			myTiles.ChangeSprite(movableTiles, 1);
			selectedNpc = null;
		}
	}

	int[] attackableTile;
	bool isAttacking = false;

	public void startAttackingNpc()
	{
		guiClicked = true;
		
		if (selectedNpc != null) {
			isAttacking = true;
			attackableTile = selectedNpc.listTilesAttack(32).ToArray();
			myTiles.ChangeSprite(attackableTile, 2);
			selectedNpc = null;
		}
	}

	void Update () {
	
		if (Input.GetKeyUp(KeyCode.Mouse0) && camScript.checkHit ()) {

			if( guiClicked)
			{
				guiClicked = false;
				return;
			}

				int pos = camScript.GetPostionTile();
				
				Tile t = Board.tiles[pos];

			if (isAttacking)
			{


				if ( t.npc != null && t.npc.party.p != currentNpc.party.p )
				{
					myMain.g.useAction(AttackAction.ATTACK, currentNpc, t.npc, 0 );

				}

				isAttacking = false;
				myTiles.ClearSprite();
				panelAction.SetActive(false);
				attackableTile = null;
				currentNpc = null;
			}

				if(movableTiles != null && currentNpc != null){
					foreach(var tilesPos in movableTiles)
					{
						if(pos == tilesPos)
						{
							Board.tiles[currentNpc.position].npc = null;
							Board.tiles[tilesPos].npc = currentNpc;
							//currentNpc.position = tilesPos;
							myMain.g.useAction(MoveAction.MOVE, currentNpc, null, tilesPos );
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

	
					if ( actions.Contains(MoveAction.MOVE))
					{
						btMove.SetActive(true);
					}
					else
					{
						btMove.SetActive(false);
					}

					if ( actions.Contains(AttackAction.ATTACK))
					{
						btAttack.SetActive(true);
					}
					else
					{
						btAttack.SetActive(false);
					}

					if ( actions.Contains(ConvertAction.Convert))
					{
						btConvert.SetActive(true);
					}
					else
					{
						btConvert.SetActive(false);
					}
				
				/*
					movableTiles = t.npc.listTilesMovement(32).ToArray();
					myTiles.ChangeSprite(movableTiles, 1);
					*/
					selectedNpc = t.npc;
					panelAction.SetActive(true);
					

				}
				else
				{
					selectedNpc = null;
					panelAction.SetActive(false);
				}
		}
	}
}
