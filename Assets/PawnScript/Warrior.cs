using UnityEngine;
using System.Collections;
using MapDataStruture;

public class Warrior : Pawn {


	int n;

	// Use this for initialization
	void Start () {
		attackRangeList = new ArrayList ();
		moveRangeList = new ArrayList ();
		targetList = new ArrayList ();
		nowAction = Action.Veiled;
		Triggered = false;
		HP = 4;
		maxHP = 4;
		attackShape = Shape.Diamond;
		maxAttackRange = 1;
		minAttackRange = 0;
		ATK = 3;
		LV = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void upgrade (){
		if (LV == 1) {
			LV++;
			maxHP+=2;
			HP+=2;
			ATK=4;
			moveRange+=1;

		} else if (LV == 2) {
			LV ++;
			maxHP+=2;
			HP+=2;
			ATK=5;
		} else if (LV == 3) {
			LV++;
			maxHP+=2;
			HP+=2;
			moveRange+=1;
		} else if (LV == 4) {
			LV++;
			maxHP+=2;
			HP+=2;
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


	
	/*public void undetect(Coordinate loc){
		if ( n > moveRange)
			return;
		else if ( n > maxAttackRange)
			return;
		if (nowGameScale == PawnController.GameScale._8X6 && PC.occupied8X6 [loc.x] [loc.y] == true)
			return;
		else if (nowGameScale == PawnController.GameScale._7X7 && PC.occupied7X7 [loc.x] [loc.y] == true)
			return;
		check [loc.x] [loc.y] = true;
		n++;
		detect (new Coordinate (pos.x + 1, pos.y));
		detect (new Coordinate (pos.x , pos.y+1));
		detect (new Coordinate (pos.x - 1, pos.y));
		detect (new Coordinate (pos.x , pos.y-1));
		n--;
		return;
	}*/
	


}
