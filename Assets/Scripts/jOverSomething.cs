using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class jOverSomething : MonoBehaviour {

	
	[SerializeField]	
	CameraScript camScript;

	[SerializeField]
	GameObject panelInfo;

	/*[SerializeField]
	Text hpText;

	[SerializeField]
	Text mpText;*/

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (camScript.checkHit ()) {
			if (camScript.GetTransform ().tag == "npc") {
				panelInfo.SetActive (true);
			} else
			{
				panelInfo.SetActive (false);
			}
		} 
	
	}
}
