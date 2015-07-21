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
	public void addGold(bool flag, int count){
		if (flag == false) {
			blueGold += count;
			Debug.Log("Blue's gold +"+count);
		} else if (flag == true) {
			redGold += count;
			Debug.Log("Red's gold +"+count);
		}
	}
}
