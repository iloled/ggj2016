using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public Text actionText;
	public Text playerName;
	public Text partyInfo;

	public Game g;

	// Use this for initialization
	void Start () {
		
		g = new Game ();
		g.initText (actionText, playerName, partyInfo);
		g.initPlayer ();
		g.initBoard ();
		g.startGame (); 

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			g.moveCurrentPlayer();
		}
	}
}
