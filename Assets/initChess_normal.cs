using UnityEngine;
using System.Collections;

public class initChess_normal : MonoBehaviour {

	int ChessboardSize=48;
	int RedWarrior = 3;
	int RedArcher = 3;
	int RedWizard = 3;
	int RedFarmer = 10;
	int BlueWarrior = 3;
	int BlueWarriorWarrior = 3;
	int BlueWarriorArcher = 3;
	int BlueWizard = 3;
	int BlueFarmer = 10;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setBoard(){
		int[] boardCode = new int[ChessboardSize];
		for (int i=0; i<ChessboardSize; i++) {
			boardCode[i] = i;
		}
		for (int i=0; i<ChessboardSize; i++) {
			int k = Random.Range(i,47);
			int temp = boardCode[k];
			boardCode[k] = boardCode[i];
			boardCode[i] = temp;
		}
		Debug.Log("set board finish");
	}
}
