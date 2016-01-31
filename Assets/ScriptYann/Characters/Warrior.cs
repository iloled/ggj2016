using UnityEngine;
using System.Collections;

public class Warrior : NPC {

	public Warrior(Player p = null) : base()
	{
		SetNPCScript script = GameObject.Find("NPCS").gameObject.GetComponent<SetNPCScript>();
		base.name = "Warrior";

		if (p != null) {
			p.party.addNPC (this);
			if (p.name == "Player 1") {
				sprite = script.spriteList [0];
			} else {
				sprite = script.spriteListRed [0];
			}
		}

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (AttackAction.ATTACK);

		hp = 10;
		mp = 4;
		maxHp = 10;
		maxMp = 4;
		pAttack = 5;
		moveRange = 3;
	}
}
