using UnityEngine;
using System.Collections;

public class MouseControl : MonoBehaviour {

	bool PawnSelected = false;
	RaycastHit MouseRayHit()
	{
		Ray ray = GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);
		return hit;
	}

	void ActionJudge()
	{
		RaycastHit hit = MouseRayHit ();
		if (Input.GetMouseButtonDown (0)) 
		{
			if(PawnSelected)
			{
				if(hit.transform.tag == "Grid"){

				}

			}
			else
			{
				if (hit.transform.tag == "Pawn") {
					GameObject TargetPawn = hit.transform.gameObject;
	  			}
			}
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}