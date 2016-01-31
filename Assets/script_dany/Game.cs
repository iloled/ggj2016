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
		p.party = new Party (p);

		var neutral = new NormalGuy ();
		neutral.position = 77;

		var m = new Messiah ();
		m.position = 78;

		p.party.addNPC  (m);

		NPC n1 = new Warrior ();

		n1.position = 5;
		n1.position = 15;
		n1.moveRange = 32;
		n1.pAttack = 100;

		NPC n2 = new Mage ();
		n2.hp = 6;
		n2.mp = 4;
		n2.maxHp = 6;
		n2.maxMp = 4;
		n2.position = 10;
		n2.position = 600;
		n2.moveRange = 2;

		p.party.addNPC  (n1);
		//p.party.addNPC  (n2);

		p2.party = new Party (p2);

		NPC n3 = new Thief ();
		n3.hp = 4;
		n3.mp = 0;
		n3.maxHp = 4;
		n3.maxMp = 0;
		n3.position = 25;
		n3.position = 430;
		n3.moveRange = 3;

		NPC n4 = new Archer ();
		n4.hp = 3;
		n4.mp = 0;
		n4.maxHp = 3;
		n4.maxMp = 0;
		n4.position = 9;
		n4.position = 100;
		n4.moveRange = 4;

		NPC neutre = new Archer ();
		neutre.hp = 3;
		neutre.mp = 0;
		neutre.maxHp = 3;
		neutre.maxMp = 0;
		neutre.position = 13;
		neutre.moveRange = 4;

		var m2 = new Messiah ();
		m2.position = 69;

		p2.party.addNPC (m2);

		//p2.party.addNPC  (n3);
		//p2.party.addNPC  (n4);

		//p2.party.addNPC  (neutral);

		listNPC.Add (m2);
		//listNPC.Add (m2);
		listNPC.Add (n1);
		//listNPC.Add (n2);
		//listNPC.Add (n3);
		//listNPC.Add (n4);

		//listNPC.Add (neutral);
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
		p.name = "Player 1";
		p2.name = "Player 2";
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
		gold.text = "Gold \n" + currentPlayer.ressource.gold;
		blood.text = "Blood \n" + currentPlayer.ressource.blood;
		holyWater.text = "Holy Water \n" + currentPlayer.ressource.holyWater;
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
			initBoard ();
			break;
		case ConvertAction.CONVERT_ARCHER:
			ritual.target = target;
			ritual.messiah = user;
			ritual.execute ();
			updateTextResource ();
			updatePartyList ();
			initBoard ();
			break;
		case ConvertAction.CONVERT_MAGE:
			ritual.target = target;
			ritual.messiah = user;
			ritual.execute ();
			updateTextResource ();
			updatePartyList ();
			initBoard ();
			break;
		case ConvertAction.CONVERT_THIEF:
			ritual.target = target;
			ritual.messiah = user;
			ritual.execute ();
			updateTextResource ();
			updatePartyList ();
			initBoard ();
			break;
		case AttackAction.ATTACK:
			attack.attacker = user;
			attack.target = target;
			attack.execute ();

			if (target.party.isEmpty ()) {
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
		b.init (listNPC);
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
