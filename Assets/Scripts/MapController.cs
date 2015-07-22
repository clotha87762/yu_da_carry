using UnityEngine;
using System.Collections;
using MapDataStruture;
using GridDataStructure;

public class MapController : MonoBehaviour {

	private MapGrid[,] Map;

	private GridState getGridState(Coordinate target_location)
	{
		MapGrid target_mapgrid = getMapGrid (target_location);
		GridState result = target_mapgrid.grid.GetComponent<Grid> ().getState();
		return result;
	}

	private void setGridState(Coordinate target_location, GridState target_state)
	{
		MapGrid target_mapgrid = getMapGrid (target_location);
		target_mapgrid.grid.GetComponent<Grid> ().setState (target_state);
	}

	private void setGridsState(Coordinate[] target_locations, GridState target_state)
	{
		int length = target_locations.Length;
		MapGrid[] target_mapgrids = getMapGrids (target_locations);
		int i;
		for (i=0; i<length; i++) {
			target_mapgrids[i].grid.GetComponent<Grid> ().setState (target_state);
		}
	}
	
	public void refreshGridState()
	{
		setAllGridState (GridState.Sleep);
	}
	
	private void setAllGridState(GridState target_state)
	{
		int i, j;
		for (i=0; i<8; i++) {
			for (j=0; j<6; j++) {
				setGridState(new Coordinate(i, j), target_state);	
			}
		}
	}

	private MapGrid getMapGrid (Coordinate target_location)
	{
		MapGrid target_mapgrid = Map [target_location.x, target_location.y];
		return target_mapgrid;
	}

	private MapGrid[] getMapGrids (Coordinate[] target_locations)
	{
		int length = target_locations.Length;
		MapGrid[] target_mapgrids = new MapGrid[length];
		int i;
		for (i=0; i<length; i++) {
			target_mapgrids[i] = getMapGrid(target_locations[i]);
		}
		return target_mapgrids;
	}

	public void showMoveRange(Coordinate[] target_locations)
	{
		setGridsState (target_locations, GridState.Move);
	}

	public void showAttackRange(Coordinate[] target_locations)
	{
		foreach (Coordinate element in target_locations) 
		{
			if(getGridState(element) == GridState.Move) setGridState(element, GridState.Both);
			else setGridState(element, GridState.Both);
		}
	}

	public void showSelect(Coordinate target_location) 
	{
		refreshGridState ();
		setGridState (target_location, GridState.Selected);
	}

	public void showRange(Coordinate[] move_range_list, Coordinate[] attack_range_list)
	{
		refreshGridState ();
		showMoveRange (move_range_list);
		showAttackRange (attack_range_list);
	}

	// Use this for initialization
	void Start () {
		Map = new MapGrid[8, 6];
		int i, j;
		for (i=0; i<8; i++) {
			for(j=0; j<6; j++) {
				Coordinate target_location = new Coordinate(i, j);
				GameObject target_grid = GameObject.Find(target_location.toString());
				if(target_grid.GetComponent<Grid>()==null) Debug.Log("MapGrid Initialization Error: Cant find target Grid.");
				if(target_location!=target_grid.GetComponent<Grid>().getLocaiotn()) Debug.Log("MapGrid Initialization Error: MapGrid and Gird location dismatch.");
				Map[i, j] = new MapGrid(target_location, target_grid, true);
			}
		}
		//setGridsState(new Coordinate[5]{new Coordinate(0, 0),new Coordinate(1,0),new Coordinate(2,0),new Coordinate(3,0),new Coordinate(4,0)}, GridState.Selected);
	}

	// Update is called once per frame
	void Update () {
	
	}
}
