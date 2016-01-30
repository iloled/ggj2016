using UnityEngine;
using System.Collections;

public class Player {

	public int position;
	public string name;
	public int actionNumber;

	public Party party;

	public Player()
	{
		party = new Party ();
	}

	public void move()
	{
		Debug.Log (this.name + "Moving");
		actionNumber--;
	}

}
