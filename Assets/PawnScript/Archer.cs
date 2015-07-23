using UnityEngine;
using System.Collections;

public class Archer : Pawn {

	// Use this for initialization
	void Start () {
		Triggered = false;
		HP = 3;
		maxHP = 3;
		attackShape = Shape.Diamond;
		maxAttackRange = 3;
		minAttackRange = 2;
		ATK = 3;
		LV = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void upgrade (int nowlevel){
		if (LV == 1) {
			LV++;
			maxHP+=1;
			HP+=1;
			
		} else if (LV == 2) {
			LV ++;
			maxHP+=2;
			HP+=2;
			ATK=4;
			moveRange +=1;
		} else if (LV == 3) {
			LV++;
			maxHP+=1;
			HP+=1;
			ATK=4;
		} else if (LV == 4) {
			LV++;
			maxHP+=2;
			HP+=2;
			moveRange +=1;
			ATK = 5;
		}
	}
	
	public void onDamage (int damage){
		HP -= damage;
	}
	
	public void attack(){
		
	}
	
	public void destroy(){
		
	}
	public  void calculateMove(){
		
	}
	
	public void calculateAttack(){
		
	}
}
