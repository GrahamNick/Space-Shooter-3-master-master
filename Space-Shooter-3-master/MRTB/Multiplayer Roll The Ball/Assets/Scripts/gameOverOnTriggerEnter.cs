using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOverOnTriggerEnter : MonoBehaviour {
	public Text winText1, winText2;
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player 1") {
			winText1.text = "Player 1 Wins";
		}
		else if (other.tag == "Player 2") {
			winText1.text = "Player 2 Wins";
		}
	}
}
