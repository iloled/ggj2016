using UnityEngine;
using System.Collections;

public class Archer : NPC {

	public Archer() : base()
	{
		base.name = "Archer";

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (AttackAction.ATTACK);
	}


}
