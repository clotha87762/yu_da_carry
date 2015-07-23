using UnityEngine;
using System.Collections;
using MapDataStruture;

public class MousePointShowRange : MonoBehaviour {

	MapController mapController;
	RaycastHit new_hit;
	RaycastHit old_hit;
	bool first_hit = true;

	void judgeAction()
	{
		Ray ray = GetComponent<Camera> ().ScreenPointToRay (Input.mousePosition);
		bool object_hit = Physics.Raycast(ray, out new_hit);
		if (object_hit) {
			if (new_hit.transform.tag == "Grid") 
			{
				Coordinate location = new_hit.transform.gameObject.GetComponent<Grid> ().getLocaiotn ();
				if (first_hit) 
				{
					mapController.showSelect (location);
					first_hit = false;
				}
				else 					
				{
					if (new_hit.transform.gameObject != old_hit.transform.gameObject) mapController.showSelect (location);
				}
				old_hit = new_hit;
			} else if (new_hit.transform.tag == "Pawn") {}
		} 
		else 
		{
			mapController.refreshGridState ();
		}
	}

	// Use this for initialization
	void Start () {
		mapController = GameObject.Find ("MapController").GetComponent<MapController> ();
	}
	
	// Update is called once per frame
	void Update () {
		judgeAction ();
	}
}
