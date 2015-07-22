using UnityEngine;
using System.Collections;

public class goldManager : MonoBehaviour {
	int blueGold;
	int redGold;
	// Use this for initialization
	void Start () {
		blueGold = 0;
		redGold = 0;
		Debug.Log("init gold finish");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addGold(int flag, int count){
		if (flag == 0) {
			blueGold += count;
			Debug.Log("Blue's gold +"+count);
		} else if (flag == 1) {
			redGold += count;
			Debug.Log("Red's gold +"+count);
		}
	}

	public void farmerGold(int flag){
		//int count = pawmManager.findFarmerGold(flag);
		//addGold (flag, count);
	}
}
