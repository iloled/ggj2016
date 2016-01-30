using UnityEngine;
using System.Collections;

public class NPC  {

	public enum player{neutral, player1,player2};
	public enum type{neutral, player1,player2};
	public enum job{neutral, player1,player2};

	public int hp;				// les points de vie
	public int mp;				// les points de mana
	public int pAttack;			// les points d'attaque
	public int range;			// la portée des attaques
	public player camp;			// le npc peut etre neutre ou sous le contrôle d'un joueur
	public Vector2 position;	// la position du npc			



	// Use this for initialization


	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public NPC(){
		hp = 10;
		mp = 1;
		pAttack = 1;
		range = 2;
		camp = player.neutral;
		job = "";
	}
		
	// deplace le NPC
	public void moveNPC(Vector2 newPosition){
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
				+"side: "+camp);
	}

}
