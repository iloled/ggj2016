using UnityEngine;
using System.Collections;

public class Player {

	public string name;
	public int actionNumber;

	public Party party;
	public Ressource ressource;

	public Player()
	{
		party = new Party (this);
		ressource = new Ressource ();

	}

	public void move()
	{
		Debug.Log (this.name + "Moving");
		actionNumber--;
	}

	// convertion de NPC
	public void convertWarrior(NPC npc){
		if (ressource.gold >= 2 && ressource.blood >= 1) {
			ressource.gold -= 2;
			ressource.blood--;


		}
	}
		

}
