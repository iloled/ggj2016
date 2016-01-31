using UnityEngine;
using System.Collections;

public class AttackAction : Action {

	public NPC attacker;
	public NPC target;

	public const string ATTACK = "Attack";

	public AttackAction()
	{
		base.name = ATTACK;
	}

	public AttackAction (Player p, NPC attacker, NPC target)
	{
		base.name = ATTACK;
		base.p = p;
		this.attacker = attacker;
		this.target = target;
	}

	protected override void behaviour()
	{
		target.hp -= attacker.pAttack;
		if (target.hp <= 0)
			target.killNPC ();
	}
}
