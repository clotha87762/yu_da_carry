using UnityEngine;
using System.Collections;



public class GridControl : MonoBehaviour {

	private float opacity = 0.5f;
	bool active = false;
	// Use this for initialization
	
	public void ActiveGrid()
	{
		active = true;
	}

	void ChangeAlpha(float alpha)
	{
		Color oldColor = GetComponent<Renderer> ().material.color;
		Color newColor = new Color (oldColor.r, oldColor.g, oldColor.b, alpha);
		GetComponent<Renderer> ().material.SetColor ("_Color", newColor);
	}

	void Start () {
		ChangeAlpha (opacity);
	}
	
	// Update is called once per frame
	void Update () {
		if (active) ChangeAlpha (1);
		else ChangeAlpha (opacity);
	}
}
