using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Boundary
{
	public float xMin, xMax, yMin, yMax, zMin, zMax;
}
public class PlayerMover : MonoBehaviour {
	public float speed;
	public float tilt;
	public float angle;
	public Boundary boundary;
	public GameObject shot;
	public Transform shotSpawn1;
	public Transform shotSpawn2;
	public Transform shotSpawn3;
	public float zRotation;
	private Quaternion originalRotation;
	public float fireDelta = 0.5f;
	private float nextFire = 0.5f;

	void Start() {
		originalRotation = transform.rotation;
	}
	void Update() {

		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireDelta;
			Instantiate (
				shot,
				shotSpawn1.position,
				shotSpawn1.rotation
			);// as GameObject;
			Instantiate (
				shot,
				shotSpawn2.position,
				shotSpawn2.rotation
			);// as GameObject;
			Instantiate (
				shot,
				shotSpawn3.position,
				shotSpawn3.rotation
			);// as GameObject;

			GetComponent<AudioSource> ().Play ();
		}


	}
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical, 0.0f);
		GetComponent<Rigidbody> ().velocity = movement * speed;

		GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (GetComponent<Rigidbody> ().position.y, boundary.yMin, boundary.yMax),
			0.0f

		);

		if (Input.GetKey (KeyCode.Q)) {
			transform.rotation = transform.rotation * Quaternion.AngleAxis (Time.deltaTime * zRotation, Vector3.forward);
		} else if (Input.GetKey (KeyCode.E)) {
			transform.rotation = transform.rotation * Quaternion.AngleAxis (Time.deltaTime * zRotation, Vector3.back);

		}
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (
			GetComponent<Rigidbody> ().velocity.y * -tilt + transform.rotation.z,
			GetComponent<Rigidbody> ().velocity.x * tilt,
			0.0f
		);
	}
}
