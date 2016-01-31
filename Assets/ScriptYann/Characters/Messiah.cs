using UnityEngine;
using System.Collections;

public class Messiah : NPC {
	
	public Messiah(Player p = null) : base()
	{
		SetNPCScript script = GameObject.Find("NPCS").gameObject.GetComponent<SetNPCScript>();
		base.name = "Prophet";

		if (p != null) {
			p.party.addNPC (this);
			if (p.name == "Player 1") {
				sprite = script.spriteList [2];
			} else {
				sprite = script.spriteListRed [2];
			}
		}
		base.name = "Prophet";
		base.moveRange = 4;

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (ConvertAction.Convert);
	}

	public void conversionType()
	{
	}
}
