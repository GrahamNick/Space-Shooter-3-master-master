using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour {
	public float speed;
	public Text CountText1;
	public Text CountText2;
	public Text WinText;

	public Rigidbody rb;
	public float distanceToGround = 0.5f;
	private int count1;
	private  int count2;
	public int MaxCount;
	public GameObject player;
	private Vector3 movement;
	void Start() {
		setCountText1 ();
		setCountText2 ();

		WinText.text = "";

		//count = 0;
		rb = GetComponent<Rigidbody> ();
		//WinText1.text = "";
	}
	void FixedUpdate (){
		if (player.tag == "Player 1") {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//			if (Input.GetKey (KeyCode.Space) && isGrounded ()) {
//				rb.AddForce (0, 300f, 0);
//			}
		} else if (player.tag == "Player 2") {
			float moveHorizontal = Input.GetAxis ("Horizontal2");
			float moveVertical = Input.GetAxis ("Vertical2");
			movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
//			if (Input.GetKey (KeyCode.Insert) && isGrounded ()) {
//				rb.AddForce (0, 300f, 0);
//			}
		}
		rb.AddForce (movement * speed);
	}
	void OnTriggerEnter(Collider other) {

		if (player.tag == "Player 1") {
			if (other.gameObject.CompareTag ("Pick Up")) {
				other.gameObject.SetActive (false);
				count1 += 1;
				setCountText1 ();
			}
		}

		else if (player.tag == "Player 2") {
			if (other.gameObject.CompareTag ("Pick Up")) {
				other.gameObject.SetActive (false);
				count2 += 1;
				setCountText2 ();
			}
		}			
	}
		
	void setCountText1 () {
		CountText1.text = "Purple Player Count: " + count1.ToString ();
		Win1 ();
	}

	void setCountText2 () {
		CountText2.text = "Green Player Count: " + count2.ToString ();
		Win2 ();
	}



	bool isGrounded() {
		return Physics.Raycast (transform.position, Vector3.down, distanceToGround);
	}
	void Win1(){
		if (count1 >= (MaxCount/2) && WinText.text == "") {
			WinText.text = "Blue Player Wins!!";
			transform.Rotate (new Vector3(15,30,45) * Time.deltaTime * Time.deltaTime);
		}
	}
	void Win2(){
		if (count2 >= (MaxCount/2) && WinText.text == "") {
			WinText.text = "Green Player Wins!!";
			transform.Rotate (new Vector3(15,30,45) * Time.deltaTime * Time.deltaTime);
		}
	}
}
