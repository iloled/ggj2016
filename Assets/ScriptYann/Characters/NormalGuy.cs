using UnityEngine;
using System.Collections;

public class NormalGuy : NPC {

	public NormalGuy() : base()
	{
		var random = Random.Range(0, 5);
		sprite = script.neutralSpriteList [random];
		base.name = "Homme";

		// Action list

		base.actions.Add (MoveAction.MOVE);
	}
}
