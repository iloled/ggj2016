using System;


public class MoveAction : Action
{

	private int position;
	private NPC npc;


	public MoveAction (Player p, NPC npc,  int position)
	{
		base.p = p;
		this.position = position;
		this.npc = npc;
	}

	protected override void behaviour()
	{
		npc.position = position;
	}
}


