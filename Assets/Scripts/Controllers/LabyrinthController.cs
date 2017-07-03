using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthController : MonoBehaviour {

	public Transform terrain;
	public Transform beacon;
	public GameObject cellPrefab;
	public int cellOffset = 1;

	public int xGridSize = 50;
	public int yGridSize = 50;

	// Use this for initialization
	void Start () {
		GenerateEmptyCells ();
	}

	public void GenerateEmptyCells () {
		Vector3 cellPos = beacon.position;
		GameObject cellCreated = null;

		for (int x = 0; x < xGridSize; x++) {
			for (int y = 0; y < yGridSize; y++) {
				cellCreated = Instantiate (cellPrefab, cellPos, cellPrefab.transform.rotation) as GameObject;
				cellCreated.transform.SetParent (terrain);
				cellPos.x += cellOffset;
			}

			cellPos.x = beacon.position.x;
			cellPos.z += cellOffset;
		}
	}
}
