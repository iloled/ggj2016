using UnityEngine;
using System.Collections;

public class Mage : NPC {

	public Mage(Player p = null) : base()
	{
		SetNPCScript script = GameObject.Find("NPCS").gameObject.GetComponent<SetNPCScript>();


		if (p != null) {
			p.party.addNPC (this);
			if (p.name == "Player 1") {
				sprite = script.spriteList [1];
			} else {
				sprite = script.spriteListRed [1];
			}
		}
		base.name = "Mage";

		hp = 4;
		mp = 4;
		maxHp = 4;
		maxMp = 4;
		pAttack = 4;
		moveRange = 2;
		range = 3;

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (AttackAction.ATTACK);
	}

	public void conversionType()
	{
	}
}
