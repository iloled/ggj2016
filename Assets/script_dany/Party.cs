﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Party {
	public List<NPC> members = new List<NPC>();
	public Player p ;

	public Party(Player p)
	{
		this.p = p;
	}


	public void addNPC(NPC n)
	{
		members.Add (n);
		n.party = this;
	}

	public void removeNPC(NPC n)
	{
		members.Remove (n);
	}

	public bool isEmpty()
	{
		return members.Count == 0;
	}
}
