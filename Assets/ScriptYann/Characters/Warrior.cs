using UnityEngine;
using System.Collections;

public class Warrior : NPC {

	public Warrior() : base()
	{
		base.name = "Warrior";

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (AttackAction.ATTACK);

		hp = 10;
		mp = 4;
		maxHp = 10;
		maxMp = 4;
	}
}
