using UnityEngine;
using System.Collections;
using MapDataStruture;

public class Farmer : Pawn {

	// Use this for initialization
	void Start () {
		attackRangeList = new ArrayList ();
		moveRangeList = new ArrayList ();
		targetList = new ArrayList ();
		nowAction = Action.Veiled;
		Triggered = false;
		HP = 1;
		maxHP = 1;
		attackShape = Shape.Diamond;
		maxAttackRange = 0;
		minAttackRange = 0;
		ATK = 0;
		LV = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onDamage (int damage){
		HP -= damage;
	}
	

	public void destroy(){
		
	}
}
