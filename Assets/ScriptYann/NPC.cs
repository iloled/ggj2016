using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NPC  {

	public enum player{neutral, player1,player2};
	public enum type{athelte,schoolboy,geek};
	public enum job{warrior, archer, mage};

	public string name;

	public int hp;				// les points de vie
	public int mp;				// les points de mana

	public int maxHp;				// les points de vie
	public int maxMp;				// les points de mana

	public int pAttack;			// les points d'attaque
	public int range;			// la portée des attaques
	public player camp;			// le npc peut etre neutre ou sous le contrôle d'un joueur
	public int position;		// la position du npc	
	public type typePerson; 	// le type du npc
	public int moveRange;		// la porté du déplacement du NPC

	public Party party;
	public List<string> actions = new List<string>();

	public Transform npcTransform;

	private AttackAction attack = new AttackAction();

	public NPC(){
		hp = maxHp =  1;
		mp = maxMp = 1;
		pAttack = 1;
		range = 1;
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
					(position +  j + i * boardSize)<boardSize*boardSize &&
				    (position +  j + i * boardSize)>=0 &&
					!result.Exists(element=>element==(position + j + i * boardSize))) {
					result.Add (position + j + i * boardSize);
//					Debug.Log(position + j + i * boardSize);
					}

				if ((position -  j + i * boardSize)>=landmark+i * boardSize &&
					(position -  j + i * boardSize)<=landmark+ i * boardSize + boardSize - 1 &&
				    (position -  j + i * boardSize)<boardSize*boardSize &&
				    (position -  j + i * boardSize)>=0 &&
					!result.Exists(element=>element==(position - j + i * boardSize)) ) {
					result.Add (position - j + i * boardSize);
	//				Debug.Log(+position - j + i * boardSize);
				}

				if ((position +  j - i * boardSize)>=landmark-i * boardSize &&
					(position +  j - i * boardSize)<=landmark- i * boardSize + boardSize - 1 &&
				    (position +  j - i * boardSize)<boardSize*boardSize &&
				    (position +  j - i * boardSize)>=0 &&
					!result.Exists(element=>element==(position + j - i * boardSize))) {
					result.Add (position + j - i * boardSize);
					//Debug.Log(position + j - i * boardSize);
				}

				if ((position -  j - i * boardSize)>=landmark-i * boardSize &&
					(position -  j - i * boardSize)<=landmark- i * boardSize + boardSize - 1 &&
				    (position -  j - i * boardSize)<boardSize*boardSize &&
				    (position -  j - i * boardSize)>=0 &&
					!result.Exists(element=>element==(position - j - i * boardSize)) ) {
					result.Add (position - j - i * boardSize);
					//Debug.Log(position - j - i * boardSize);
				}

				}

			}
		return result;
	}

	// donne les case où le npc peut se deplacer
	//-- précondition: le npc dois se trouver sur une case valide
	public List<int> listTilesAttack(int boardSize){
		
		//-- calcul de la ligne pour les bordures
		int landmark=0;
		while (position > landmark + boardSize - 1)
			landmark += boardSize;
		
		List<int> result= new List<int>();
		
		//-- le cas où le npc n'est pas sur le plateau
		for (int i=0; i <= range; i++) {
			for (int j = range-i; j >= 0; j--) {
				
				//-- si la case ne depasse la ordure
				if ((position +  j + i * boardSize)>=landmark+i * boardSize &&
				    (position +  j + i * boardSize)<=landmark+ i * boardSize + boardSize - 1 &&
				    (position +  j + i * boardSize)<boardSize*boardSize &&
				    (position +  j + i * boardSize)>=0 &&
				    !result.Exists(element=>element==(position + j + i * boardSize))) {
					result.Add (position + j + i * boardSize);
					//					Debug.Log(position + j + i * boardSize);
				}
				
				if ((position -  j + i * boardSize)>=landmark+i * boardSize &&
				    (position -  j + i * boardSize)<=landmark+ i * boardSize + boardSize - 1 &&
				    (position -  j + i * boardSize)<boardSize*boardSize &&
				    (position -  j + i * boardSize)>=0 &&
				    !result.Exists(element=>element==(position - j + i * boardSize)) ) {
					result.Add (position - j + i * boardSize);
					//				Debug.Log(+position - j + i * boardSize);
				}
				
				if ((position +  j - i * boardSize)>=landmark-i * boardSize &&
				    (position +  j - i * boardSize)<=landmark- i * boardSize + boardSize - 1 &&
				    (position +  j - i * boardSize)<boardSize*boardSize &&
				    (position +  j - i * boardSize)>=0 &&
				    !result.Exists(element=>element==(position + j - i * boardSize))) {
					result.Add (position + j - i * boardSize);
					//Debug.Log(position + j - i * boardSize);
				}
				
				if ((position -  j - i * boardSize)>=landmark-i * boardSize &&
				    (position -  j - i * boardSize)<=landmark- i * boardSize + boardSize - 1 &&
				    (position -  j - i * boardSize)<boardSize*boardSize &&
				    (position -  j - i * boardSize)>=0 &&
				    !result.Exists(element=>element==(position - j - i * boardSize)) ) {
					result.Add (position - j - i * boardSize);
					//Debug.Log(position - j - i * boardSize);
				}
				
			}
			
		}
		return result;
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

	public string getDescription()
	{
		var text = "";
		text += name + "\n";
		text += "HP : " +hp + "/"+maxHp+"\n";
		text += "MP : " +mp + "/" + maxMp+ "\n\n";
		return text;
	}


	public void killNPC()
	{
		this.party.removeNPC (this);
		Debug.Log ("dead bitch " + name);
		npcTransform.gameObject.SetActive (false);
		//npcTransform.enabled = false;
	}

	public List<string> actionList()
	{
		return actions;
	}

	public void useAction(string actionName) 
	{
		switch (actionName) {
			case MoveAction.MOVE:
				break;
			case ConvertAction.Convert:
				break;
			case AttackAction.ATTACK:
				break;
		 
		}
	}

}
