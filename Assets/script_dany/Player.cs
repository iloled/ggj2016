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

	 
	// =============   Convertion des NPC  ============== //

	public void convertWarrior(NPC npc){
		if (ressource.gold >= 1 && ressource.blood >= 1 && ressource.holyWater>=1) {
			ressource.gold --;
			ressource.blood--;
			ressource.holyWater--;

			int position = npc.position;
			npc = new Warrior ();
			npc.setPosition (position);
			this.party.addNPC (npc);
		}
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


	public void convertMage(NPC npc){
		if (ressource.blood >= 3) {
			ressource.blood -= 3;

			int position = npc.position;
			npc = new Mage ();
			npc.setPosition (position);
			this.party.addNPC (npc);
		}
	}


	public void converttThief(NPC npc){
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
