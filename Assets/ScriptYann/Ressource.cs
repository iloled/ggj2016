using UnityEngine;
using System.Collections;

public class Ressource   {

	public int position;
	public int blood, gold, holyWater;

	public Ressource(){
		blood = 0;
		gold = 0;
		holyWater = 0;
	}

	public Ressource(int blood, int gold, int holyWater){
		this.blood = blood;
		this.gold = gold;
		this.holyWater = holyWater;
	}

	public void addAllRessource(){
		blood ++;
		gold ++;
		holyWater ++;
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
