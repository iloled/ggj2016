﻿using UnityEngine;
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

	 
	// =============   Convertion des NPC  ============== //

	public bool hasEnoughResourceForWarrior()
	{
		Debug.Log (ressource.gold );
		Debug.Log (ressource.blood );
		Debug.Log (ressource.holyWater );
		Debug.Log (ressource.gold >= 1 && ressource.blood >= 1 && ressource.holyWater >= 1);
		return ressource.gold >= 1 && ressource.blood >= 1 && ressource.holyWater >= 1;
	}

	public void removeWarriorResource()
	{
		ressource.gold --;
		ressource.blood--;
		ressource.holyWater--;
	}

	public void convertWarrior(NPC npc){
		if (ressource.gold >= 1 && ressource.blood >= 1 && ressource.holyWater>=1) {
			removeWarriorResource ();

			int position = npc.position;
			npc = new Warrior ();
			npc.setPosition (position);
			this.party.addNPC (npc);
		}
	}

	public bool hasEnoughResourceForArcher()
	{
		return ressource.blood >= 1 && ressource.holyWater>=2;
	}

	public void removeArcherResource()
	{
		ressource.blood --;
		ressource.holyWater -=2;
	}

	public void convertArcher(NPC npc){
		if ( ressource.blood >= 1 && ressource.holyWater>=2) {
			ressource.blood --;
			ressource.holyWater -=2;

			int position = npc.position;
			npc = new Archer ();
			npc.setPosition (position);
			this.party.addNPC (npc);
		}
	}	

	public bool hasEnoughResourceForMage()
	{
		return ressource.blood >= 3;
	}

	public void removeMageResource()
	{
		ressource.blood -= 3;
	}

	public void convertMage(NPC npc){
		if (ressource.blood >= 3) {
			ressource.blood -= 3;

			int position = npc.position;
			npc = new Mage ();
			npc.setPosition (position);
			this.party.addNPC (npc);
		}
	}

	public bool hasEnoughResourceForThief()
	{
		return ressource.gold >= 2 && ressource.blood>=2;
	}


	public void removeThiefResource()
	{
		ressource.gold -= 2;
		ressource.blood -= 2;
	}

	public string getMageStats( NPC target )
	{
		var text = ""; 
		text += "HP : "+ (target.hp + 2 ) + "\n";
		text += "ATK : 4\n";
		text += "RANGE : 2\n";
		return text;
	}

	public string getWarriorStats( NPC target )
	{
		var text = ""; 
		text += "HP : "+ (target.hp + 10 ) + "\n";
		text += "ATK : 5\n";
		text += "MOVE : 3\n";
		return text;
	}

	public string getThiefStats( NPC target )
	{
		var text = ""; 
		text += "HP : "+ (target.hp + 5 ) + "\n";
		text += "ATK : 3\n";
		text += "MOVE : 4\n";
		return text;
	}

	public string getArcherStats( NPC target )
	{
		var text = ""; 
		text += "HP : "+ (target.hp + 3 ) + "\n";
		text += "ATK : 2\n";
		text += "RANGE : 3\n";
		return text;
	}

	public void convertThief(NPC npc){
		if (ressource.gold >= 2 && ressource.blood>=2) {
			ressource.gold -= 2;
			ressource.blood -= 2;

			int position = npc.position;
			npc = new Thief ();
			npc.setPosition (position);
			this.party.addNPC (npc);
		}
	}

}
