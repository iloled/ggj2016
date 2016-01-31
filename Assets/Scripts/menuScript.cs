using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuScript : MonoBehaviour {
	public Text text;

	public void Start()
	{
		text.text = "Winner : " +Globals.WINNER;
	}
	public void exitApplication()
	{
		Application.Quit ();
	}

	public void startApplication(int idlevel)
	{
		Application.LoadLevel (idlevel);
	}



}
