using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructionGuiController : MonoBehaviour {

	public GameObject[] guiToHide;
	public Image selectedBlockImage;

	public void HideConstructionElement () {
		foreach (GameObject element in guiToHide) {
			element.SetActive (false);
		}
	}

	public void ActualizeSelectedBlock(Color color) {
		selectedBlockImage.color = color;
	}
}
