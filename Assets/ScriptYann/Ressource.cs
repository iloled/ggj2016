using UnityEngine;
using System.Collections;

public class Ressource   {

	public int position;
	public int blood, gold, holyWater;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public Ressource(){
		blood = 1;
		gold = 1;
		holyWater = 1;
	}
		

	public void setPosition(int newPosition){
		position = newPosition;
	}

	public void addRandomRessource(){
		int choice = Random.Range (0, 3);
			switch (choice) {
		case 0:
			blood++;
			break;

		case 1:
			gold++;
			break;

		case 2:
			holyWater++;
			break;

		}

	}
}
