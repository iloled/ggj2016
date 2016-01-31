using UnityEngine;
using System.Collections;

public class Archer : NPC {

	public Archer() : base()
	{
		base.name = "Archer";
		hp = 4;
		maxHp = 4;

		mp = 0;
		maxMp = 0;

		moveRange = 3;
		pAttack = 2;
		range = 3;

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (AttackAction.ATTACK);
	}


}
