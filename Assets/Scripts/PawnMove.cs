using UnityEngine;
using System.Collections;

public class PawnMove : MonoBehaviour {

	public enum ShapeType
	{
		Diamond,
		Square,
		Cross,
	};

	public struct Coordinate
	{
		public int x;
		public int y;
		public Coordinate(int _x, int _y) {x=_x; y=_y;}
	};

	public int Range;
	public ShapeType Shape;
	public Coordinate Location = new Coordinate(0, 0);
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

	void UpdateMoveRange()
	{

	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
