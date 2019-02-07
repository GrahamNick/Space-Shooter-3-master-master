using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	private Vector3 trans1;
	private Vector3 trans2;
	private Vector3 startpos;
	// Use this for initialization
	void Start () {
		
		startpos = this.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		trans1 = player1.transform.position;
		trans2 = player2.transform.position;
		this.transform.position = (trans1 + trans2) / 2 + startpos ;

		// attempting to adjust height
		float height = Mathf.Abs(trans1.z - trans2.z) + Mathf.Abs(trans1.x -trans2.x);
		this.transform.position = new Vector3 (this.transform.position.x, height + startpos.y, this.transform.position.z);

	}
}
