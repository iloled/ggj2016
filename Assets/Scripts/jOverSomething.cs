﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class jOverSomething : MonoBehaviour {

	
	[SerializeField]	
	CameraScript camScript;

	[SerializeField]
	GameObject panelInfo;

	[SerializeField]
	Text descText;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (camScript.checkHit ()) {
			if (camScript.GetTransform ().tag == "npc") {
				//panelInfo.SetActive (true);
				//if(Board.tiles[camScript.GetPostionTile()].npc != null)
					//descText.text = Board.tiles[camScript.GetPostionTile()].npc.getDescription();;
				//
			} else
			{
				//panelInfo.SetActive (false);
			}
		} 
	
	}
}
