using UnityEngine;
using System.Collections;

public class rightClickCancel : MonoBehaviour {

	public gameStateManager GSM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GSM.state == 2) {
			if(Input.GetMouseButtonDown(1)){
				if(GSM.actionState == 2){
					//if updated, can't go back
				}
				else if(GSM.actionState == 3 ){
					//close update window
					//open select window
					GSM.setActionState(2);
				}
				else if(GSM.actionState == 4 ){
					//open select window
					GSM.setActionState(2);
				}
			}
		}
	}
}
