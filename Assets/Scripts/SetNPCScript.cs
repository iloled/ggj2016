using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetNPCScript : MonoBehaviour {
	
	[SerializeField]
	TileScript tiles;

	[SerializeField]
	Transform[] NPCTransform;

	List<NPC> npcs = new List<NPC>();



	// Use this for initialization
	void Start () {

		/*npcs [0] = new NPC (NPC.type.athelte);
		npcs [0].position = 15;

		npcs [1] = new NPC (NPC.type.geek);
		npcs [1].position = 600;

		npcs [2] = new NPC (NPC.type.schoolboy);
		npcs [2].position = 135;

		npcs [3] = new NPC (NPC.type.geek);
		npcs [3].position = 802;

		npcs [4] = new NPC (NPC.type.athelte);
		npcs [4].position = 201;*/



	}

	public void PlaceObjectNPC(List<NPC> npc)
	{
		int i = 0;
		//Debug.Log("ok");
		foreach (var elem in npc) {


			var tiletransform = tiles.GetTileTransform(elem.position);
			Debug.Log("ok");
			NPCTransform[i].position = new Vector3(tiletransform.position.x, 
			                                       tiletransform.position.y,
			                                       tiletransform.position.z);
			Board.tiles[elem.position].npc = elem; 
			++i;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.A))
		{
			//PlaceObjectNPC (npcs);
		}
	}
}
