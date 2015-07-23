using UnityEngine;
using System.Collections;
using MapDataStruture;
using System.Linq;
using DG.Tweening;

public class PawnSpriteMove : MonoBehaviour {
	public float gridScale = 2.0f;
	public float gridMoveDuration = 1.0f;
	public Vector3[] pathPoints;
	// Use this for initialization
	void Start () {
		/*
		int i;
		for (i=0; i<pathPoints.Length; i++)
			pathPoints [i] *= gridScale;
		transform.DOPath (pathPoints, pathPoints.Length * gridMoveDuration, PathType.Linear);
		*/
		Coordinate[] range_list1 = new Coordinate[] {new Coordinate (0, 0), new Coordinate (1, 0), new Coordinate (1, 1)};
		Coordinate[] range_list2 = new Coordinate[] {new Coordinate (0, 0), new Coordinate (1, 0), new Coordinate (3, 1), new Coordinate(1, 1), new Coordinate(1, 9)};

		Coordinate[] range_catt1 = range_list1.Concat (range_list2).ToArray ();
		range_catt1 = range_catt1.Distinct ().ToArray ();

		foreach (Coordinate element in range_catt1) {
			Debug.Log(element.toString());
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
