using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
	public float speed;
	public float min=2f;
	public float max=3f;
	// Use this for initialization
	void Start () {
		min=transform.position.x;
		max=transform.position.x+3;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime * speed);

	}
}
