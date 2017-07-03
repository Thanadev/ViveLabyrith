using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockService : MonoBehaviour {

	public GameObject[] blocks;

	private GameObject currentBlock;

	void Awake () {
		currentBlock = blocks [0];
	}

	public GameObject CurrentBlock {
		get {
			return this.currentBlock;
		}
	}
}
