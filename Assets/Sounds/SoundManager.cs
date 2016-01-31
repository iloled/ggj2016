using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public GameObject sword;
	public GameObject convert;
	public GameObject fire;

	public void playSword()
	{
		sword.SetActive (false);
		sword.SetActive (true);
	}

	public void playFire()
	{
		fire.SetActive (false);
		fire.SetActive (true);
	}

	public void playConvert()
	{
		convert.SetActive (false);
		convert.SetActive (true);
	}
}
