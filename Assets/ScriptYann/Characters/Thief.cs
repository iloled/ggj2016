using UnityEngine;
using System.Collections;

public class Thief : NPC {

	public Thief() : base()
	{
		base.name = "Thief";

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (AttackAction.ATTACK);
	}
}
