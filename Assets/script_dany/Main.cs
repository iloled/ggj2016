using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	Game g;

	// Use this for initialization
	void Start () {
		Debug.Log ("ntm ian");
		g = new Game ();
		g.startGame ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			g.moveCurrentPlayer();
		}
	}
}
