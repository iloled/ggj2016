using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC  {

	public enum player{neutral, player1,player2};
	public enum type{athelte,schoolboy,geek};
	public enum job{warrior, archer, mage};

	public int hp;				// les points de vie
	public int mp;				// les points de mana
	public int pAttack;			// les points d'attaque
	public int range;			// la portée des attaques
	public player camp;			// le npc peut etre neutre ou sous le contrôle d'un joueur
	public int position;		// la position du npc	
	public type typePerson; 	// le type du npc
	public int moveRange;		// la porté du déplacement du NPC

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
		position = -1;  				//signifie que le NPC ne trouve pas sur le plateau
		moveRange=2;

	}

	public void setPosition(int newPosition){
		position = newPosition;
	}
		
	// donne les case où le npc peut se deplacer
	//-- précondition: le npc dois se trouver sur une case valide
	public List<int> listTilesMovement(int boardSize){

		//-- calcul de la ligne pour les bordures
		int landmark=0;
		while (position > landmark + boardSize - 1)
			landmark += boardSize;

			List<int> result= new List<int>();

		//-- le cas où le npc n'est pas sur le plateau
		for (int i=0; i <= moveRange; i++) {
				for (int j = moveRange-i; j >= 0; j--) {

					//-- si la case ne depasse la ordure
				if ((position +  j + i * boardSize)>=landmark+i * boardSize &&
					(position +  j + i * boardSize)<=landmark+ i * boardSize + boardSize - 1 &&
					(position +  j + i * boardSize)<boardSize*boardSize) {
					result.Add (position + j + i * boardSize);
					Debug.Log(position + j + i * boardSize);
					}

				if ((position -  j + i * boardSize)>=landmark+i * boardSize &&
					(position -  j + i * boardSize)<=landmark+ i * boardSize + boardSize - 1 &&
					(position -  j + i * boardSize)<boardSize*boardSize ) {
					result.Add (position - j + i * boardSize);
					Debug.Log(position - j + i * boardSize);
				}

				if ((position +  j - i * boardSize)>=landmark-i * boardSize &&
					(position +  j - i * boardSize)<=landmark- i * boardSize + boardSize - 1 &&
					(position +  j - i * boardSize)<boardSize*boardSize) {
					result.Add (position + j - i * boardSize);
					Debug.Log(position + j - i * boardSize);
				}

				if ((position -  j - i * boardSize)>=landmark-i * boardSize &&
					(position -  j - i * boardSize)<=landmark- i * boardSize + boardSize - 1 &&
					(position -  j - i * boardSize)<boardSize*boardSize ) {
					result.Add (position - j - i * boardSize);
					Debug.Log(position - j - i * boardSize);
				}

				}

			}
		return result;
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
				+"type: "+typePerson+"\ncase :"+position);
	}

}
