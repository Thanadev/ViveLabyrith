using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockService : MonoBehaviour {

	public DialogBoxController dialogBox;
	public GameObject[] blocks;
    public GameObject launchGameButton;

	private GameObject currentBlock;
	private bool spawnPlaced = false;

	void Awake () {
		currentBlock = blocks [0];
        launchGameButton.GetComponent<Button>().interactable = false;
        launchGameButton.GetComponent<BoxCollider>().enabled = false;
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

            if (spawnPlaced == true)
            {
                launchGameButton.GetComponent<Button>().interactable = true;
                launchGameButton.GetComponent<BoxCollider>().enabled = true;
            } else
            {
                launchGameButton.GetComponent<Button>().interactable = false;
                launchGameButton.GetComponent<BoxCollider>().enabled = false;
            }
		}
	}
}
