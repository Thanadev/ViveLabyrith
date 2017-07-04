using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionGuiController : MonoBehaviour {

	public GameObject[] guiToHide;

	public void HideConstructionElement () {
		foreach (GameObject element in guiToHide) {
			element.SetActive (false);
		}
	}
}
