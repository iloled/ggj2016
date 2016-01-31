using System;
using UnityEngine;

public class MoveAction : Action
{

	public int position;
	public NPC npc;

	public const  string MOVE = "Move";

	public MoveAction()
	{
		base.name = MOVE;
	}

	public MoveAction (Player p, NPC npc,  int position)
	{
		base.name = MOVE;
		base.p = p;
		this.position = position;
		this.npc = npc;
	}

	protected override void behaviour()
	{
		npc.deleteSprite ();
		npc.position = position;
		Debug.Log (npc + " move to " + npc.position);
		npc.setSprite ();
	}

}


