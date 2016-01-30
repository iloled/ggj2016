using UnityEngine;
using System.Collections;


public class ConvertAction : Action
{
	public NPC attacker;
	public NPC target;

	public const string Convert = "Conversion";

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

	public void convert()
	{
	}

}


