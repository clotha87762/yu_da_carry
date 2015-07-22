using UnityEngine;
using System.Collections;

public class SpriteFaceCamera : MonoBehaviour {

	public enum Type
	{
		Sphere,
		Rectangle,
	}

	public Type type;
	private Transform target;

	// Use this for initialization
	void Start () {
		target = Camera.main.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if (type==Type.Sphere) transform.LookAt(target.position, Vector3.up);
		else if (type==Type.Rectangle) transform.rotation = target.rotation;

	}
}
