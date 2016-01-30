using UnityEngine;
using System.Collections;

public class AttackAction : Action {

	private int position;
	private NPC attacker;
	private NPC target;

	public AttackAction (Player p, NPC attacker, NPC target)
	{
		base.p = p;
		this.attacker = attacker;
		this.target = target;
	}

	protected override void behaviour()
	{
		target.hp -= attacker.pAttack;
		if (attacker.hp <= 0)
			attacker.killNPC ();
	}
}
