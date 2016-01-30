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
			Debug.Log ("hit");
			if (camScript.GetTag () == "npc") {
				panelInfo.SetActive (true);
			} else
			{
				panelInfo.SetActive (false);
			}
		} 
	
	}
}
