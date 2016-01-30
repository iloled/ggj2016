using UnityEngine;
using System.Collections;

public class Game  {

	static int ACTION_PER_TURN = 2; 

	Player p = new Player();
	Player p2 = new Player();
	Player currentPlayer;

	private bool firstTurn = true;
	// Use this for initialization
	void Start () {
	
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
			} else {
				currentPlayer = p;
			}
		} else {
			firstTurn = false;
		}

		Debug.Log ("Phase : " + currentPlayer.name);
		currentPlayer.actionNumber = ACTION_PER_TURN;
	}

	public void moveCurrentPlayer()
	{
		playAction (null);
	}

	public void playAction(Action a)
	{
		currentPlayer.move();
		if (currentPlayer.actionNumber == 0) 
		{
			playNextPhase ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
