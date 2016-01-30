using UnityEngine;
using System.Collections;

public class Mage : NPC {

	public Mage() : base()
	{
		base.name = "Mage";

		// Action list

		base.actions.Add (MoveAction.MOVE);
	}

	public void conversionType()
	{
	}
}
