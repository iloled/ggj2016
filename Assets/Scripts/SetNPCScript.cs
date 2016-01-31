using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetNPCScript : MonoBehaviour {

	public Transform prefabNPC;

	[SerializeField]
	TileScript tiles;

	[SerializeField]
	Transform[] NPCTransform;

	[SerializeField]
	Sprite[] spriteList;

	[SerializeField]
	Sprite[] neutralSpriteList;

	public Sprite[] SpriteList {
		get {
			return spriteList;
		}
	}

	int testI = 0;

	List<NPC> npcs = new List<NPC>();

	// Use this for initialization
	void Start () {



	}




	public void PlaceObjectNPC(List<NPC> npc)
	{
		int i = 0;
		foreach (var elem in npc) {
			Debug.Log (elem.name);
			var tiletransform = tiles.GetTileTransform(elem.position);

			NPCTransform[i].position = new Vector3(tiletransform.position.x, 
			                                       tiletransform.position.y,
			                                       tiletransform.position.z);
			elem.npcTransform = NPCTransform[i];
			//NPCTransform[i].gameObject.SetActive (true);

			Board.tiles[elem.position].npc = elem; 
			++i;
		}

	}

	public void createNPC(int idTile, Sprite sprite)
	{
		var x = idTile%32;
		var y = idTile/32;

		Transform newNPC = GameObject.Instantiate(prefabNPC, 
		                                          new Vector3(1+x, 1+y, 0.0f), 
		                                          Quaternion.identity) as Transform;

		Debug.Log ("new NPCCC : " + newNPC.name);
		newNPC.parent = this.gameObject.transform;
		SpriteRenderer srender = newNPC.transform.GetComponent<SpriteRenderer> ();
		srender.sprite = sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.F12))
		{
			int randID = Random.Range(0,5);
			createNPC (testI, neutralSpriteList[randID]);
			++testI;
		}
	}
}
