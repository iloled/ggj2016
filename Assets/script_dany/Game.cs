using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Game  {

	static int ACTION_PER_TURN = 2; 

	Player p = new Player();
	Player p2 = new Player();
	Player p3 = new Player();
	Player currentPlayer;
	Board b = new Board();

	public Text actionText;
	public Text playerName;
	public Text partyInfo;

	private bool firstTurn = true;

	public void initPlayer()
	{
		p.party = new Party ();

		NPC n1 = new NPC ();
		n1.name = "Warrior";
		n1.hp = 10;
		n1.mp = 4;
		n1.maxHp = 10;
		n1.maxMp = 4;

		NPC n2 = new NPC ();
		n2.name = "Mage";
		n2.hp = 6;
		n2.mp = 4;
		n2.maxHp = 6;
		n2.maxMp = 4;

		p.party.members.Add (n1);
		p.party.members.Add (n2);

		p2.party = new Party ();

		NPC n3 = new NPC ();
		n3.name = "Thief";
		n3.hp = 4;
		n3.mp = 0;
		n3.maxHp = 4;
		n3.maxMp = 0;

		NPC n4 = new NPC ();
		n4.name = "Archer";
		n4.hp = 3;
		n4.mp = 0;
		n4.maxHp = 3;
		n4.maxMp = 0;

		p2.party.members.Add (n3);
		p2.party.members.Add (n4);
	}	

	public void initText( Text action, Text playerName, Text partyInfo )
	{
		actionText = action;
		this.playerName = playerName;
		this.partyInfo = partyInfo;
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
			} else if (currentPlayer == p2) {
				
				currentPlayer = p3;
				playNeutralPhase ();
			} else {
				currentPlayer = p;
			}
		} else {
			firstTurn = false;
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

	private void updatePartyList()
	{
		Party p = currentPlayer.party;

		string text = "";

		foreach (NPC n in p.members) {
			text += n.name + "\n";
			text += n.hp + "/"+n.maxHp+"\n";
			text += n.mp + "/" + n.maxMp+ "\n\n";
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
		Action a = new Action (currentPlayer);
		a.execute ();
		updateActionText ();
		if (currentPlayer.actionNumber == 0) 
		{
			playNextPhase ();
		}
	}


}
