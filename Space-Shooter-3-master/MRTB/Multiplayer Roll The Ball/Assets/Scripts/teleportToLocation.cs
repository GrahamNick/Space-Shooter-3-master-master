using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleportToLocation : MonoBehaviour {
	public string location;
	public void OnTriggerEnter (Collider other){
		SceneManager.LoadScene (location);
	}
}
