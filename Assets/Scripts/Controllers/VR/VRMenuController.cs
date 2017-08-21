using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMenuController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)) {
			TriggerPressedHandler ();
		}
	}

	private void TriggerPressedHandler () {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			VRMenuPlayButton playButton = hit.collider.GetComponent<VRMenuPlayButton> ();

			if (playButton != null) {
				playButton.StartGame ();
			}
		}
	}
}
