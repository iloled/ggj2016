using UnityEngine;
using System.Collections;

public class Game  {

	static int ACTION_PER_TURN = 2; 

	Player p = new Player();
	Player p2 = new Player();
	Player p3 = new Player();
	Player currentPlayer;
	Board b = new Board();

	private bool firstTurn = true;

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
		if (currentPlayer.actionNumber == 0) 
		{
			playNextPhase ();
		}
	}


}
