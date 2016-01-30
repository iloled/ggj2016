using UnityEngine;
using System.Collections;

public class SetNPCScript : MonoBehaviour {
	
	[SerializeField]
	TileScript tiles;

	[SerializeField]
	Transform[] NPCTransform;

	NPC[] npcs = new NPC[5];
	// Use this for initialization
	void Start () {

		npcs [0] = new NPC (NPC.type.athelte);
		npcs [0].position = 15;

		npcs [1] = new NPC (NPC.type.geek);
		npcs [1].position = 600;

		npcs [2] = new NPC (NPC.type.schoolboy);
		npcs [2].position = 135;

		npcs [3] = new NPC (NPC.type.geek);
		npcs [3].position = 802;

		npcs [4] = new NPC (NPC.type.athelte);
		npcs [4].position = 201;



	}

	public void PlaceObjectNPC(NPC[] npc)
	{
		int i = 0;

		foreach (var elem in npc) {
			var tiletransform = tiles.GetTileTransform(elem.position);

			NPCTransform[i].position = new Vector3(tiletransform.position.x, 
			                                       tiletransform.position.y,
			                                       tiletransform.position.z);
			++i;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.A))
		{
			PlaceObjectNPC (npcs);
		}
	}
}
