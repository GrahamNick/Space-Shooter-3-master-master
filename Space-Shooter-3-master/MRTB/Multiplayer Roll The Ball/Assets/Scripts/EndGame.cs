using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour {
	public GameObject Player1;
	public GameObject Player2;
	private Vector3 startpos;
	public Text WinText;
	// Use this for initialization
	void Start () {
		WinText.text = "";
		startpos = Player1.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Player1.transform.position.y <= 0 && WinText.text == "") {
			WinText.text = "Purple Player Wins!!";
			Player1.gameObject.SetActive (false);
		}
		if (Player2.transform.position.y <= 0 && WinText.text == "") {

			WinText.text = "Green Player Wins!!";
			Player2.gameObject.SetActive (false);
		}
		if ((Player1.gameObject.activeSelf && Player1.transform.position.y <= 0) && !(Player2.gameObject.activeSelf)) {
			Player1.gameObject.SetActive (false);
		}

		if ((Player2.gameObject.activeSelf && Player2.transform.position.y <= 0) && !(Player1.gameObject.activeSelf)) {
			Player2.gameObject.SetActive (false);
		}
	}
}
