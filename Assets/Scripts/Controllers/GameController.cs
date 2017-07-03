using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Camera constructionCamera;
	public BlockService blockS;
	public ConstructionGuiController constructionGui;

	private GamePhase phase;
	private Ray mouseRay;
	private RaycastHit cellHit;
	private CellController selectedCell;

	// Use this for initialization
	void Awake () {
		phase = GamePhase.CONSTRUCTION;
	}
	
	// Update is called once per frame
	void Update () {
		if (phase == GamePhase.CONSTRUCTION) {
			if (Input.GetMouseButton (0)) {
				selectedCell = null;
				GetSelectedCell ();

				if (selectedCell != null) {
					if (blockS.CanPlaceCurrentBlock ()) {
						selectedCell.SetBlock (blockS.CurrentBlock);

						if (blockS.CurrentBlock.CompareTag ("PlayerSpawn")) {
							blockS.SpawnPlaced = true;
						}
					}
				}
			} else if (Input.GetMouseButton (1)) {
				selectedCell = null;
				GetSelectedCell ();

				if (selectedCell != null) {
					selectedCell.EmptyCell ();

					if (blockS.CurrentBlock.CompareTag ("PlayerSpawn")) {
						blockS.SpawnPlaced = false;
					}
				}
			}
		}
	}

	public void LaunchGame () {
		phase = GamePhase.PLAY;
		CellController[] cells = FindObjectsOfType<CellController> ();
		constructionGui.HideConstructionElement ();

		foreach (CellController cell in cells) {
			cell.HidePlaceholder ();
		}

		FindObjectOfType<PlayerSpawnController> ().SpawnPlayer ();
		constructionCamera.gameObject.SetActive (false);
	}

	private void GetSelectedCell () {
		mouseRay = constructionCamera.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (mouseRay, out cellHit)) {
			selectedCell = cellHit.collider.GetComponent<CellController> ();
		}
	}

	public enum GamePhase {
		CONSTRUCTION, 
		PLAY
	};
}
