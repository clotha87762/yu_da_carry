using UnityEngine;
using System.Collections;

public class gameStateManager : MonoBehaviour {
	int turnCount;
	int playerFlag;
	public int state;
	public int actionState;

	goldManager GM;
	gameRule_normal GR;

	// Use this for initialization
	void Start () {
		turnCount = 0;
		state = 0;
		actionState = 0;

		GM = gameObject.GetComponent<goldManager> ();
		GR = gameObject.GetComponent<gameRule_normal>();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == 0) {
		
		} 
		else if (state == 1) {
			GM.farmerGold(playerFlag);

			setGameState(2);
			setActionState(1);
		}
		else if (state == 2) {
		
		}
		else if (state == 3) {
			//call pwanManager atk function
			changePlayer();
			if(GR.judgeGameover()==true){
				setGameState(0);
			}
			setGameState(1);
		}
	}

	public void setPlayerFlag(int flag){
		playerFlag = flag;
		Debug.Log("set playerFlag finish");
	}
	public void changePlayer(){
		if (playerFlag == 0)
			playerFlag = 1;
		else
			playerFlag = 0;
	}
	public void setGameState(int num){
		state = num;
		Debug.Log("change state to "+num);
	}
	public void setActionState(int num){
		actionState = num;
		//Debug.Log("change actionState to "+num);
	}
}
