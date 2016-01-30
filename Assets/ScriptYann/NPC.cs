using UnityEngine;
using System.Collections;

public class NPC  {

	public enum player{neutral, player1,player2};
	public enum type{athelte,schoolboy,geek};
	public enum job{warrior, archer, mage};

	public int hp;				// les points de vie
	public int mp;				// les points de mana
	public int pAttack;			// les points d'attaque
	public int range;			// la portée des attaques
	public player camp;			// le npc peut etre neutre ou sous le contrôle d'un joueur
	public int position;	// la position du npc			



	// Use this for initialization


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public NPC(type typeNPC){
		switch (typeNPC) {
		case type.athelte:
						hp = 20;
						break;

		case type.schoolboy:
						hp = 5;
						break;

		case type.geek:
						hp = 10;
						break;

		default:
				hp = 10;
				break;
		}

		mp = 1;
		pAttack = 1;
		range = 1;
		camp = player.neutral;
		typePerson = typeNPC;

	}
		
	// deplace le NPC
	public void moveNPC(int newPosition){
		position = newPosition;
	}

	//le NPC attaque
	public int attack(){
		return pAttack;
	}

	//le NPC est attaqué
	public void isAttacked(int damage){
		hp -= damage;
	}

	//le NPC est convertie
	public void convert(player joueur){
		camp = joueur;
	}

	//le NPC est convertie
	public void showStat(){
		Debug.Log ("Statistics:\n"
				+hp+" hp\n"
				+mp+" mp\n"
				+pAttack+" attack\n"
				+"type: "+typePerson);
	}

}
