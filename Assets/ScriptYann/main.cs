﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class main : MonoBehaviour {

	public NPC npc;

	// Use this for initialization
	void Start () {
		npc= new NPC(NPC.type.schoolboy);
		npc.setPosition (12);
		npc.showStat();
		npc.isAttacked (7);
		npc.convert(NPC.player.player1);
		npc.showStat();
		List<int> list=npc.listTilesMovement (5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
