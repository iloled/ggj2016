using UnityEngine;
using System.Collections;

public class menuScript : MonoBehaviour {


	public void exitApplication()
	{
		Application.Quit ();
	}

	public void startApplication(int idlevel)
	{
		Application.LoadLevel (idlevel);
	}



}
