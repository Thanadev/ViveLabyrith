using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour {

	public GameObject placeholder;

	private GameObject currentBlock;

	public void SetBlock (GameObject prefab) {
		if (currentBlock != null) {
			Destroy (currentBlock);
		}

		currentBlock = GameObject.Instantiate (prefab, placeholder.transform.position, prefab.transform.rotation, transform) as GameObject;
		placeholder.SetActive (false);
	}

	public void EmptyCell () {
		if (currentBlock != null) {
			Destroy (currentBlock);
			placeholder.SetActive (true);
		}
	}

	public void HidePlaceholder () {
		placeholder.SetActive (false);
	}
}
