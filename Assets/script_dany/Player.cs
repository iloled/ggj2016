using UnityEngine;
using System.Collections;

public class Player {

	public string name;
	public int actionNumber;

	public void move()
	{
		Debug.Log (this.name + "Moving");
		actionNumber--;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
