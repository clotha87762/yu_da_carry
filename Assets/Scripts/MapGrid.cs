using UnityEngine;
using System.Collections;
using MapDataStruture;
using GridDataStructure;

public class MapGrid : MonoBehaviour {

	public Coordinate location;
	public GameObject grid;
	public bool ocuppied = true;
	// Use this for initialization
	public MapGrid(Coordinate _location,GameObject _grid, bool _ocuppied)
	{
		location = _location;
		grid = _grid;
		ocuppied = _ocuppied;
	}
	
}

