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

	[SerializeField]
	GameObject ritualPanel;

	[SerializeField]
	GameObject mageButton;

	[SerializeField]
	GameObject warriorButton;

	[SerializeField]
	GameObject thiefButton;

	[SerializeField]
	GameObject archerButton;

	[SerializeField]
	Text mageStats;

	[SerializeField]
	Text warriorStats;

	[SerializeField]
	Text thiefStats;

	[SerializeField]
	Text archerStats;


	public NPC selectedNpc;

	NPC currentNpc;
	Player currentPlayer;
	int[] movableTiles;
	bool guiClicked = false;
	bool isMoving = false;

	public void startMovingNpc()
	{
		guiClicked = true;

		if (selectedNpc != null) {
			isMoving = true;
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

	int[] convertTileRange;
	bool isConverting = false;
	NPC ritualTarget = null;

	public void startConvert()
	{
		guiClicked = true;
		if (selectedNpc != null) {
			isConverting = true;
			attackableTile = selectedNpc.listTileConvert(32).ToArray();
			myTiles.ChangeSprite(attackableTile, 2);
			selectedNpc = null;
		}
	}

	public void cancelRitual()
	{
		guiClicked = true;
		ritualPanel.SetActive (false);
	}

	public void warriorRitual()
	{
		popScript script = GameObject.Find("popManager").gameObject.GetComponent<popScript>();
		script.popConvert (ritualTarget.position);
		myMain.g.useAction (ConvertAction.Convert, currentNpc, ritualTarget, 0);
		ritualPanel.SetActive (false);
		ritualTarget = null;
		currentNpc = null;
	}

	public void mageRitual()
	{
		popScript script = GameObject.Find("popManager").gameObject.GetComponent<popScript>();
		script.popConvert (ritualTarget.position);
		myMain.g.useAction (ConvertAction.CONVERT_MAGE, currentNpc, ritualTarget, 0);
		ritualPanel.SetActive (false);
		ritualTarget = null;
		currentNpc = null;
	}



	public void archerRitual()
	{
		myMain.g.useAction (ConvertAction.CONVERT_ARCHER, currentNpc, ritualTarget, 0);
		ritualPanel.SetActive (false);
		ritualTarget = null;
		currentNpc = null;
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
				if ( t.npc != null && (t.npc.party == null || t.npc.party.p != currentNpc.party.p) )
				{
					myMain.g.useAction(AttackAction.ATTACK, currentNpc, t.npc, 0 );

				}

				isAttacking = false;
				myTiles.ClearSprite();
				panelAction.SetActive(false);
				attackableTile = null;
				currentNpc = null;
			}

			if (isConverting) {
				if ( t.npc != null && t.npc.isNeutral() )
				{
					ritualTarget = t.npc;
					//myMain.g.useAction(ConvertAction.Convert, currentNpc, t.npc, 0 );
					ritualPanel.SetActive(true);

					mageButton.SetActive (currentNpc.party.p.hasEnoughResourceForMage());
					warriorButton.SetActive (currentNpc.party.p.hasEnoughResourceForWarrior());
					thiefButton.SetActive (currentNpc.party.p.hasEnoughResourceForThief());
					archerButton.SetActive (currentNpc.party.p.hasEnoughResourceForArcher());

					mageStats.text = currentNpc.party.p.getMageStats (ritualTarget);
					warriorStats.text = currentNpc.party.p.getWarriorStats (ritualTarget);
					archerStats.text = currentNpc.party.p.getArcherStats (ritualTarget);
					thiefStats.text = currentNpc.party.p.getThiefStats (ritualTarget);

				}

				isConverting = false;
				myTiles.ClearSprite();
				panelAction.SetActive(false);
				convertTileRange = null;
				//currentNpc = null;
				return;
			}
			Debug.Log (currentPlayer);
			Debug.Log (t.npc);
			if (t.npc != null) {
				Debug.Log (t.npc.party);
			}


			if(isMoving){
				foreach(var tilesPos in movableTiles)
				{
					if(pos == tilesPos)
					{
						Board.tiles[currentNpc.position].npc = null;
						Board.tiles[tilesPos].npc = currentNpc;
						//currentNpc.position = tilesPos;
						myMain.g.useAction(MoveAction.MOVE, currentNpc, null, tilesPos );
						currentNpc = null;
						//myMain.g.initBoard();

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
				isMoving = false;
			}
			else if(t.npc != null && myMain.g.currentPlayer == t.npc.party.p )
			{
				Debug.Log ("inside");
				currentNpc = t.npc;
				currentPlayer =currentNpc.party.p;
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
				Debug.Log ("forever alone");
				selectedNpc = null;
				panelAction.SetActive(false);
			}
		}
	}
}
