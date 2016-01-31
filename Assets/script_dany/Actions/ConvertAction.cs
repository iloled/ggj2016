using UnityEngine;
using System.Collections;


public class ConvertAction : Action
{
	public NPC messiah;
	public NPC target;

	public const string Convert = "Ritual";
	public const string EXECUTE_RITUAL = "execute_ritual";

	public ConvertAction ()
	{
		base.name = Convert;
	}

	public ConvertAction (Player p, NPC attacker, NPC target)
	{
		base.name = Convert;
		base.p = p;
		this.attacker = attacker;
		this.target = target;
	}


	protected override void behaviour()
	{

	}

}


