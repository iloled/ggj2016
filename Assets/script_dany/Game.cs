using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Game  {

	static int ACTION_PER_TURN = 3; 

	Player p = new Player();
	Player p2 = new Player();
	Player p3 = new Player();
	public Player currentPlayer;
	Board b = new Board();

	public static List<NPC> listNPC = new List<NPC> ();

	public Text actionText;
	public Text playerName;
	public Text partyInfo;
	public Text gold;
	public Text blood;
	public Text holyWater;

	private bool firstTurn = true;

	public void initPlayer()
	{
		SetNPCScript script = GameObject.Find("NPCS").gameObject.GetComponent<SetNPCScript>();

		p.name = "Player 1";
		p2.name = "Player 2";
		p.party = new Party (p);

		var neutral = new NormalGuy ();
		neutral.position = 237;

		var neutral2 = new NormalGuy ();
		neutral2.position = 47;

		var neutral3 = new NormalGuy ();
		neutral3.position = 945;

		var neutral4 = new NormalGuy ();
		neutral4.position = 954;

		var neutral5 = new NormalGuy ();
		neutral5.position = 320;

		var neutral6 = new NormalGuy ();
		neutral6.position = 535;

		var neutral7 = new NormalGuy ();
		neutral7.position = 732;

		var neutral8 = new NormalGuy ();
		neutral8.position = 650;

		var neutral9 = new NormalGuy ();
		neutral9.position = 286;

		var neutral10 = new NormalGuy ();
		neutral10.position = 833;

		var m = new Messiah (p);
		m.position = 78;

		p.party.addNPC  (m);

		NPC n1 = new Warrior (p);

		n1.position = 5;

		n1.moveRange = 32;
		n1.pAttack = 100;

		NPC n2 = new Mage (p);

		n2.position = 85;
		n2.moveRange = 2;


		NPC n3 = new Warrior (p2);


		n3.position = 972;
		n3.moveRange = 32;
		n3.pAttack = 100;

		NPC n4 = new Mage (p2);

		n4.position = 990;
		n4.moveRange = 2;


		p2.party = new Party (p2);

		var m2 = new Messiah (p2);
		m2.position = 948;
		p2.party.addNPC (m2);

		//p2.party.addNPC  (n4);

		//p2.party.addNPC  (neutral);

		listNPC.Add (m);
		listNPC.Add (m2);
		listNPC.Add (n1);
		listNPC.Add (n2);
		listNPC.Add (n3);
		listNPC.Add (n4);
		//listNPC.Add (n4);

		listNPC.Add (neutral);
		listNPC.Add (neutral2);
		listNPC.Add (neutral3);
		listNPC.Add (neutral4);
		listNPC.Add (neutral5);
		listNPC.Add (neutral6);
		listNPC.Add (neutral7);
		listNPC.Add (neutral8);
		listNPC.Add (neutral9);
		listNPC.Add (neutral10);

		initBoard ();


	}

	public void initText( Text action, Text playerName, Text partyInfo, Text gold, Text blood, Text holyWater  )
	{
		actionText = action;
		this.playerName = playerName;
		this.partyInfo = partyInfo;
		this.gold = gold;
		this.blood = blood;
		this.holyWater = holyWater;
	}

	public void startGame()
	{
		Debug.Log ("Start game");

		currentPlayer = p;
		playNextPhase();
	}

	private void playNextPhase()
	{
		if (!firstTurn) {
			
			if (currentPlayer == p) {
				currentPlayer = p2;
				updateRessource ();
			} else if (currentPlayer == p2) {
				
				currentPlayer = p3;
				playNeutralPhase ();
			} else {
				currentPlayer = p;
				updateRessource ();
			}
		} else {
			firstTurn = false;
			updateRessource ();
		}


		Debug.Log ("Phase : " + currentPlayer.name);
		currentPlayer.actionNumber = ACTION_PER_TURN;

		updateActionText ();
		updatePartyList ();
		playerName.text = currentPlayer.name;

	}

	private void updateActionText()
	{
		actionText.text = "Remaining actions : " + currentPlayer.actionNumber;
	}

	private void updateRessource(){
		
		currentPlayer.ressource.addAllRessource ();
		updateTextResource ();

	}

	public void updateTextResource()
	{
		/*gold.text = "Gold \n" + currentPlayer.ressource.gold;
		blood.text = "Blood \n" + currentPlayer.ressource.blood;
		holyWater.text = "Holy Water \n" + currentPlayer.ressource.holyWater;*/

		gold.text = currentPlayer.ressource.gold.ToString ();
		blood.text = currentPlayer.ressource.blood.ToString ();
		holyWater.text = currentPlayer.ressource.holyWater.ToString();
	}

	private void updatePartyList()
	{
		Party p = currentPlayer.party;

		string text = "";

		foreach (NPC n in p.members) {
			text += n.getDescription ();
		}
		partyInfo.text = text;
	}

	private void playNeutralPhase()
	{
		Debug.Log ("Neutral phase");

		playNextPhase ();
	}

	public void moveCurrentPlayer()
	{
		useAction (MoveAction.MOVE, currentPlayer.party.members[0], null, 0);
		/*
		Action a = new Action (currentPlayer);
		a.execute ();
		updateActionText ();
		if (currentPlayer.actionNumber == 0) 
		{
			playNextPhase ();
		}*/
	}

	private AttackAction attack = new AttackAction ();
	private MoveAction move = new MoveAction ();
	private ConvertAction ritual = new ConvertAction ();

	public void useAction(string actionName, NPC user, NPC target, int position)
	{
		// Use action

		switch (actionName) {

		case MoveAction.MOVE:
			move.npc = user;
			move.position = position;
			move.execute ();
			break;
		case ConvertAction.Convert:
			ritual.target = target;
			ritual.messiah = user;
			ritual.execute ();
			updateTextResource ();
			updatePartyList ();
			break;
		case ConvertAction.CONVERT_ARCHER:
			ritual.target = target;
			ritual.messiah = user;
			ritual.execute ();
			updateTextResource ();
			updatePartyList ();
			break;
		case ConvertAction.CONVERT_MAGE:
			ritual.target = target;
			ritual.messiah = user;
			ritual.convertToMage ();
			updateTextResource ();
			updatePartyList ();
			break;
		case ConvertAction.CONVERT_THIEF:
			ritual.target = target;
			ritual.messiah = user;
			ritual.execute ();
			updateTextResource ();
			updatePartyList ();
			break;
		case AttackAction.ATTACK:
			Debug.Log ("attack");
			attack.attacker = user;
			attack.target = target;
			attack.execute ();

			if (target.party != null && target.party.isEmpty ()) {
				Globals.WINNER = currentPlayer.name;
				Application.LoadLevel ("gameOverScene");
				Debug.Log ("mainScene");
			}
			break;
		}

		currentPlayer.actionNumber--;
		updateActionText ();

		if (currentPlayer.actionNumber == 0) 
		{
			playNextPhase ();
		}
	}

	public void initBoard()
	{
		SetNPCScript script = GameObject.Find("NPCS").gameObject.GetComponent<SetNPCScript>();
		//b.init (listNPC);
		foreach (var NPC in listNPC) {
			NPC.setSprite ();
			Board.tiles [NPC.position].npc = NPC;

		}
	}

	public static void removeNPC( NPC npc)
	{
		Debug.Log (npc.name + " as been killed");
		listNPC.Remove (npc);
	}

	public static void addNPC( NPC npc)
	{

		listNPC.Add (npc);
	}



}
