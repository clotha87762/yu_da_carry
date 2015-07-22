using UnityEngine;
using System.Collections;
using MapDataStruture;
using GridDataStructure;

public class Grid : MonoBehaviour {

	public static float gridScale = 2.0f;


	//setting list
	public float lerp_duration = 1.0f;
	public float unactive_opacity = 0.1f;
	public float min_active_opacity = 0.2f;
	public float max_active_opacity = 0.5f;
	public Color color_sleep = new Color (0.5f, 0.5f, 0.5f);
	public Color color_move = new Color (0, 0, 1);
	public Color color_attack = new Color (1, 0, 0);
	public Color color_both = new Color (1, 0, 1);
	public Color color_selected = new Color (0.9f, 0.9f, 0.9f);


	private GridState state = GridState.Sleep;
	private Coordinate location;


	void changeAlpha(float alpha)
	{
		Color oldColor = GetComponent<Renderer> ().material.color;
		Color newColor = new Color (oldColor.r, oldColor.g, oldColor.b, alpha);
		GetComponent<Renderer> ().material.SetColor ("_Color", newColor);
	}

	void changeColor(Color color)
	{
		Color oldColor = GetComponent<Renderer> ().material.color;
		Color newColor = new Color (color.r, color.g, color.b, oldColor.a);
		GetComponent<Renderer> ().material.SetColor ("_Color", newColor);
	}

	void changeColor(float R, float G, float B)
	{
		Color oldColor = GetComponent<Renderer> ().material.color;
		Color newColor = new Color (R, G, B, oldColor.a);
		GetComponent<Renderer> ().material.SetColor ("_Color", newColor);
	}

	//lerpAlpha, lerp alpha form bAlpha to eAlpha in duration (simple-harmonicly)
	void lerpAlpha()
	{
		lerpAlpha (lerp_duration);
	}

	void lerpAlpha(float duration)
	{
		lerpAlpha (duration, min_active_opacity, max_active_opacity);
	}

	void lerpAlpha(float duration, float bAlpha, float eAlpha)
	{
		float lerp = Mathf.PingPong (Time.time, duration) / duration;
		float alpha = Mathf.Lerp(bAlpha, eAlpha, lerp);
		changeAlpha(alpha);
	}

	//setState, public method to change the state of grid and swap to the corresponding color
	public GridState setState(GridState _state)
	{
		state = _state;
		if (state == GridState.Move)
						changeColor (color_move);
				else if (state == GridState.Attack)
						changeColor (color_attack);
				else if (state == GridState.Both)
						changeColor (color_both);
				else if (state == GridState.Sleep)
						changeColor (color_sleep);
				else if (state == GridState.Selected)
						changeColor (color_selected);
		return state;
	}

	public GridState getState()
	{
		return state;
	}

	public Coordinate getLocaiotn()
	{
		return location;
	}

	void Start () {
		string _name = name;
		Debug.Log ("Grid Name: " + name);
		location = new Coordinate(_name[1]-'0', _name[3]-'0'); 
		//location = Coordinate.toCoordinate (name);
		Debug.Log ("Grid Coordinate: " + "(" + location.x + "," + location.y + ")");
		changeAlpha (unactive_opacity);
		//setState (GridState.Move);
	}
	
	// Update is called once per frame
	void Update () {
		//detect state color, and set

		if (state!=GridState.Sleep) lerpAlpha();
		else if (state==GridState.Sleep) changeAlpha (unactive_opacity);
	}
}
