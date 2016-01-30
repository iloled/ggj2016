using UnityEngine;
using System.Collections;

public class testCameraScript : MonoBehaviour {

	[SerializeField]
	CameraScript camScript;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			if(camScript.checkHit())
			{
				int pos = camScript.GetPostionTile();
				Debug.Log (pos);
			}	
		}
	
	}
}
