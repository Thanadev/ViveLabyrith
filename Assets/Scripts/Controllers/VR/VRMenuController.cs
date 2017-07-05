using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRMenuController : MonoBehaviour {

	private SteamVR_TrackedController controller;

	// Use this for initialization
	void Awake () {
        controller = GetComponent<SteamVR_TrackedController>();
		controller.TriggerClicked += TriggerPressedHandler;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void TriggerPressedHandler (object sender, ClickedEventArgs args) {
		RaycastHit hit;

		if (Physics.Raycast (transform.position, transform.forward, out hit)) {
			VRMenuPlayButton playButton = hit.collider.GetComponent<VRMenuPlayButton> ();

			if (playButton != null) {
				playButton.StartGame ();
			}
		}
	}
}
