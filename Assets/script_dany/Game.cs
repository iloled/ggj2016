using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class Game  {

	static int ACTION_PER_TURN = 3; 

	Player p = new Player();
	Player p2 = new Player();
	Player p3 = new Player();
	Player currentPlayer;
	Board b = new Board();

	List<NPC> listNPC = new List<NPC> ();

	public Text actionText;
	public Text playerName;
	public Text partyInfo;
	public Text gold;
	public Text blood;
	public Text holyWater;


	private bool firstTurn = true;

	public void initPlayer()
	{
		p.party = new Party ();

		var m = new Messiah ();

		p.party.members.Add (m);

		NPC n1 = new Warrior ();

		n1.position = 5;
		n1.position = 15;
		n1.moveRange = 1;

		NPC n2 = new Mage ();
		n2.hp = 6;
		n2.mp = 4;
		n2.maxHp = 6;
		n2.maxMp = 4;
		n2.position = 10;
		n2.position = 600;
		n2.moveRange = 2;

		p.party.members.Add (n1);
		p.party.members.Add (n2);

		p2.party = new Party ();

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

		var m2 = new Messiah ();

		p2.party.members.Add (m2);

		p2.party.members.Add (n3);
		p2.party.members.Add (n4);

		listNPC.Add (n1);
		listNPC.Add (n2);
		listNPC.Add (n3);
		listNPC.Add (n4);
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
		gold.text = "Gold : " + currentPlayer.ressource.gold;
		blood.text = "Blood : " + currentPlayer.ressource.blood;
		holyWater.text = "Holy Water : " + currentPlayer.ressource.holyWater;

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

	public void useAction(string actionName, NPC user, NPC target, int position)
	{
		// Use action

		switch (actionName) {

		case MoveAction.MOVE:
			move.npc = user;
			move.execute ();
			break;
		case ConvertAction.Convert:
			break;
		case AttackAction.ATTACK:
			attack.attacker = user;
			attack.target = target;
			attack.execute ();
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



}
