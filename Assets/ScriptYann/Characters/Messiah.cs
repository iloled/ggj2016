using UnityEngine;
using System.Collections;

public class Messiah : NPC {
	
	public Messiah() : base()
	{
		base.name = "Messiah";
		base.moveRange = 4;

		// Action list

		base.actions.Add (MoveAction.MOVE);
		base.actions.Add (ConvertAction.Convert);
	}

	public void conversionType()
	{
	}
}
