using UnityEngine;
using System.Collections;

public class raycast : MonoBehaviour {

	RaycastHit pastHit;

	public gameStateManager GSM;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

		if (GSM.state == 2) {
			if(GSM.actionState==1|GSM.actionState==2|GSM.actionState==4){
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit ;
				Physics.Raycast (ray , out hit);
				
				//if(GSM.actionState==1&Input.GetMouseButtonDown(1)) click and is pawn , go pawnM
				//else if(hit == pastHit){}
				//else{
					//pastHit = hit
					//remove
					//if() pastHit is Grid , go pawnM
					//else() pastHit is pawn, go pawnM?
							
					//light
					//if()not click and is pawn , go pawnM
					//else if() not click and is grid , go pawnM
				//}
			}
		}
		
	}
}
