using UnityEngine;
using System.Collections;

public class PawnMove : MonoBehaviour {
	public enum ShapeType
	{
		Diamond,
		Square,
		Cross,
	}
	public struct Coordinate
	{
		int x;
		int y;
	}

	public int Range;
	public ShapeType Shape;
	private Coordinate[] MoveRange;
	// Use this for initialization
	int CountMoveGrid()
	{
		int count;
		if (Shape == ShapeType.Diamond)
						count = 2 * Range * Range + 2 * Range + 1;
				else if (Shape == ShapeType.Square)
						count = 3 * (2 * Range + 1);
				else if (Shape == ShapeType.Cross)
						count = 4 * Range + 1;
				else
						count = 1;
		return count;
	}

	void CreateMoveRange()
	{
		if (Shape == ShapeType.Diamond) 
		{
			int count = CountMoveGrid();
			MoveRange = new Coordinate[CountMoveGrid()];
		}
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
