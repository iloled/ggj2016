using UnityEngine;
using System.Collections;

public class NormalGuy : NPC {

	public NormalGuy() : base()
	{
		base.name = "Homme";

		// Action list

		base.actions.Add (MoveAction.MOVE);
	}
}
