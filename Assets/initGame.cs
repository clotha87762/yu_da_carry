using UnityEngine;
using System.Collections;

public class initGame : MonoBehaviour {


	// Use this for initialization
	void Start () {
		initChess_normal initC = gameObject.GetComponent<initChess_normal> ();
		initOrder initO = gameObject.GetComponent<initOrder> ();

		initC.setBoard ();
		initO.setOrder ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
