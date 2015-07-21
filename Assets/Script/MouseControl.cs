using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

	void ShowRoute()
	{
		Ray ray = GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}