using UnityEngine;
using System.Collections;


public class ConvertAction : Action
{
	public NPC messiah;
	public NPC target;

	public const string Convert = "Ritual";
	public const string CONVERT_MAGE = "RITUAL_MAGE";
	public const string CONVERT_THIEF = "RITUAL_THEIF";
	public const string CONVERT_WARRIOR = "RITUAL_WARRIOR";
	public const string CONVERT_ARCHER = "RITUAL_ARCHER";
	public const string EXECUTE_RITUAL = "execute_ritual";

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

	public void convertToMage(NPC target)
	{
	}

	public void convertToThief(NPC target)
	{
	}

	public void convertToArcher(NPC target)
	{
		var npc = new Archer ();
		npc.name = "converted archer";
		npc.hp += target.hp;
		npc.maxHp += target.maxHp;

		npc.mp += target.mp;
		npc.maxMp += target.maxMp;
		npc.position = target.position;
		Game.removeNPC (target);
		target.killNPC ();
		Board.tiles [npc.position].npc = npc;
		messiah.party.addNPC (npc);
		messiah.party.p.removeArcherResource ();
		Game.addNPC (npc);
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
		Game.removeNPC (target);
		target.killNPC ();
		Board.tiles [npc.position].npc = npc;
		messiah.party.addNPC (npc);
		messiah.party.p.removeWarriorResource ();
		Game.addNPC (npc);
	}

}


