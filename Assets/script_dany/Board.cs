using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Board  {

	public static Tile[] tiles = new Tile[1024];


	SetNPCScript setNpcScript;


	public Board()
	{
		int i = 0;

		while (i < 1024) {
			tiles[i] = new Tile();
			++i;
		}
	}

	public void init(List<NPC> lstNPC)
	{

		setNpcScript = GameObject.Find("NPCS").gameObject.GetComponent<SetNPCScript>();
		
		/*npcScript = otherGameObject.GetComponent<YetAnotherScript>();

		setNpcScript = new SetNPCScript ();*/

		setNpcScript.PlaceObjectNPC (lstNPC);
	}
}
