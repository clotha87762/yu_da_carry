using UnityEngine;
using System.Collections;

public class initGame : MonoBehaviour {
	public gameStateManager GSM;
	// Use this for initialization
	void Start () {
		initChess_normal initC = gameObject.GetComponent<initChess_normal> ();
		initOrder initO = gameObject.GetComponent<initOrder> ();

		initC.setBoard ();
		initO.setOrder ();

		GSM.setGameState (1);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
