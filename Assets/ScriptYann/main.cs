using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

	public NPC npc;

	// Use this for initialization
	void Start () {
		npc= new NPC(NPC.type.schoolboy);
		npc.showStat();
		npc.isAttacked (7);
		npc.convert(NPC.player.player1);
		npc.showStat();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
