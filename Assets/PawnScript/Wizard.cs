using UnityEngine;
using System.Collections;

public class Wizard : Pawn {

	// Use this for initialization
	void Start () {
		Triggered = false;
		HP = 3;
		maxHP = 3;
		attackShape = Shape.Diamond;
		maxAttackRange = 2;
		minAttackRange = 0;
		ATK = 2;
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
			maxHP+=1;
			HP+=1;
			ATK=3;
			moveRange +=1;
		} else if (LV == 3) {
			LV++;
			maxHP+=1;
			HP+=1;
			ATK=4;
		} else if (LV == 4) {
			LV++;
			maxHP+=1;
			HP+=1;
		}

	}
	
	public void onDamage (int damage){
		HP -= damage;
	}
	
	public void attack(){
		
	}
	
	public void destroy(){
		Destroy (this);
	}

	public  void calculateMove(){
		
	}
	
	public void calculateAttack(){
		
	}
}
