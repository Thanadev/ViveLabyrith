using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitController : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			Debug.Log ("Exited");
		}
	}
}
