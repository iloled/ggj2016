using UnityEngine;
using System.Collections;


public class ConvertAction : Action
{
	public NPC messiah;
	public NPC target;

	public const string Convert = "Ritual";
	public const string EXECUTE_RITUAL = "execute_ritual";

	SetNPCScript npcScript;

	public ConvertAction ()
	{
		base.name = Convert;
	}

	public ConvertAction (Player p, NPC attacker, NPC target)
	{
		base.name = Convert;
		base.p = p;
		this.target = target;
	}


	protected override void behaviour()
	{
		var npc = new Warrior ();
		npc.name = "converted warrior";
		npc.hp += target.hp;
		npc.maxHp += target.maxHp;

		npc.mp += target.mp;
		npc.maxMp += target.maxMp;
		npc.position = target.position;
		//SetNPCScript
		//target.ChangeNPCSprite (npcScript.SpriteList[1]);

		//Game.removeNPC (target);
		//target.killNPC ();
		Board.tiles [npc.position].npc = npc;
		messiah.party.addNPC (npc);
		messiah.party.p.removeWarriorResource ();
		Game.addNPC (npc);
	}

}


