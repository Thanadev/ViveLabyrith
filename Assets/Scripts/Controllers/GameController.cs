using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Camera constructionCamera;
	public BlockService blockS;

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
				GetSelectedCell ();
				selectedCell.SetBlock (blockS.CurrentBlock);
			} else if (Input.GetMouseButton (1)) {
				GetSelectedCell ();
				selectedCell.EmptyCell ();
			}
		}
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
