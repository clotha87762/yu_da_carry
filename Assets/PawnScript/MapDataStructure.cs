using UnityEngine;
using System.Collections;

namespace MapDataStruture{

	//Coordinate Type, include x and y
	public struct Coordinate
	{
		public int x;
		public int y;
		public Coordinate(int _x, int _y) {x=_x; y=_y;}
		public Coordinate(Coordinate rhs) {x=rhs.x; y=rhs.y;}

		public static Coordinate operator+(Coordinate lhs, Coordinate rhs)
		{
			Coordinate result = new Coordinate (lhs.x + rhs.x, lhs.y + rhs.y);
			return result;
		}
		public static Coordinate operator-(Coordinate lhs, Coordinate rhs)
		{
			Coordinate result = new Coordinate (lhs.x - rhs.x, lhs.y - rhs.y);
			return result;
		}
		public static Coordinate operator-(Coordinate rhs)
		{
			Coordinate result = new Coordinate (-rhs.x, -rhs.y);
			return result;
		}
		public static bool operator==(Coordinate lhs, Coordinate rhs)
		{
			return (lhs.x == rhs.x && lhs.y == rhs.y); 
		}
		public static bool operator!=(Coordinate lhs, Coordinate rhs)
		{
			return !(lhs.x == rhs.x && lhs.y == rhs.y); 
		}
		public string toString()
		{
			return string.Format("("+x+","+y+")");
		}
		public static Coordinate toCoordinate(string rhs)
		{
			string[] sub_strings = rhs.Split(',');
			Coordinate result = new Coordinate(int.Parse(sub_strings[0]), int.Parse(sub_strings[1])); 
			return result;
		}



	};
}
