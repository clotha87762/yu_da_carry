using UnityEngine;
using System.Collections;

public class gameStateManager : MonoBehaviour {
	int turnCount;
	int team;
	public int state;
	public int actionState;

	public PawnController PC;
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
			GM.farmerGold(team);
			PC.turnStart(team);

			setGameState(2);
			setActionState(1);
		}
		else if (state == 2) {
		
		}
		else if (state == 3) {
			//call pwanManager atk function
			changeTeam();
			if(GR.judgeGameover()==true){
				setGameState(0);
			}
			addTurnCount();
			setGameState(1);
		}
	}

	public void setTeam(int flag){
		team = flag;
		Debug.Log("set team finish");
	}
	public void changeTeam(){
		if (team == 0)
			team = 1;
		else
			team = 0;
	}
	public void setGameState(int num){
		state = num;
		Debug.Log("change state to "+num);
	}
	public void setActionState(int num){
		actionState = num;
		//Debug.Log("change actionState to "+num);
	}
	public void addTurnCount(){
		turnCount++;
	}
}
