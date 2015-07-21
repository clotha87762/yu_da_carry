using UnityEngine;
using System.Collections;

public class initOrder : MonoBehaviour {
	public gameStateManager GSM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void setOrder(){
		bool flag;
		flag = (Random.Range (0, 1)==1?true:false);
		GSM.setPlayerFlag (flag);
		Debug.Log("set order finish");
	}
}
