using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthController : MonoBehaviour {

	public GameObject beacon;
	public GameObject cellPrefab;
	public int cellOffset = 1;

	public int xGridSize = 50;
	public int yGridSize = 50;

	// Use this for initialization
	void Start () {
		GenerateEmptyCells ();
	}

	public void GenerateEmptyCells () {
		Vector3 cellPos = beacon.transform.position;

		for (int x = 0; x < xGridSize; x++) {
			for (int y = 0; y < yGridSize; y++) {
				Instantiate (cellPrefab, cellPos, cellPrefab.transform.rotation);
				cellPos.x += cellOffset;
			}

			cellPos.x = beacon.transform.position.x;
			cellPos.z += cellOffset;
		}
	}
}
