using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxController : MonoBehaviour {

	public float secondsToDisappear = 1;
	public Text textLabel;

	// Use this for initialization
	void Start () {
		gameObject.SetActive (false);
	}

	public void DisplayText (MessageType message) {
		bool display = false;

		switch (message) {
		case MessageType.SPAWN_ALREADY_PLACED:
			textLabel.text = "Only one spawn can be placed";
			display = true;
			break;
		default:
			break;
		}

		if (display) {
			gameObject.SetActive (true);
			StartCoroutine (HideTimer ());
		}
	}

	private IEnumerator HideTimer () {
		yield return new WaitForSeconds (secondsToDisappear);
		gameObject.SetActive (false);
	}

	public enum MessageType {
		SPAWN_ALREADY_PLACED
	}
}
