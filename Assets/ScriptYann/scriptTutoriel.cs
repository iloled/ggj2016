﻿using UnityEngine;
using System.Collections;

public class scriptTutoriel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Mouse0))
			Application.LoadLevel("mainScene");
	}
}
