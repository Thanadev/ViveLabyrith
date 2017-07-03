using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockService : MonoBehaviour {

	public DialogBoxController dialogBox;
	public GameObject[] blocks;

	private GameObject currentBlock;
	private bool spawnPlaced = false;

	void Awake () {
		currentBlock = blocks [0];
	}

	public void SelectBlock (int index) {
		if (index >= 0 && index < blocks.Length) {
			if (spawnPlaced && blocks [index].CompareTag ("PlayerSpawn")) {
				dialogBox.DisplayText (DialogBoxController.MessageType.SPAWN_ALREADY_PLACED);
			} else {
				currentBlock = blocks [index];
			}
		}
	}

	public bool CanPlaceCurrentBlock () {
		bool canPlace = true;

		if (spawnPlaced && currentBlock.CompareTag ("PlayerSpawn")) {
			canPlace = false;
			dialogBox.DisplayText (DialogBoxController.MessageType.SPAWN_ALREADY_PLACED);
		}

		return canPlace;
	}

	public GameObject CurrentBlock {
		get {
			return this.currentBlock;
		}
	}

	public bool SpawnPlaced {
		get {
			return this.spawnPlaced;
		}
		set {
			spawnPlaced = value;
		}
	}
}
