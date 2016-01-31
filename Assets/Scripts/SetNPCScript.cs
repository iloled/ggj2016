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

	public void createNPC(Vector3 pos, Sprite sprite)
	{
		Transform newNPC = GameObject.Instantiate(prefabNPC, pos, Quaternion.identity) as Transform;

		Debug.Log ("new NPCCC : " + newNPC.name);

		SpriteRenderer srender = newNPC.transform.GetComponent<SpriteRenderer> ();
		srender.sprite = sprite;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKeyDown(KeyCode.A))
		{
			int randID = Random.Range(0,5);
			float randX = Random.Range(1,33);
			float randY = Random.Range(1,33);

			Debug.Log ( randX + " " + randY + " " + randID);

			createNPC (new Vector3 (randX, randY, -0.1f), neutralSpriteList[randID]);
		}
	}
}
