using UnityEngine;
using System.Collections;

public class gameStateManager : MonoBehaviour {
	int turnCount;
	bool playerFlag;
	int state;

	// Use this for initialization
	void Start () {
		turnCount = 0;
		state = 0;
	}
	
	// Update is called once per frame
	void Update () {
		/*if (state == 0) {
		
		} 
		else if (state == 1) {
		
		}
		else if (state == 2) {
			
		}
		else if (state == 3) {
			
		}*/
	}

	public void setPlayerFlag(bool flag){
		playerFlag = flag;
		Debug.Log("set playerFlag finish");
	}
	public void setGameState(int num){
		state = num;
		Debug.Log("change state to "+num);
	}
}
