using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionLazerConroller : MonoBehaviour {

	private ConstructionGuiController constructionGui;
	private GameController gameC;
	private RaycastHit hit; 
	private LineRenderer line;

	void Start () {
		gameC = FindObjectOfType<GameController>();
		constructionGui = FindObjectOfType<ConstructionGuiController> ();
		line = GetComponent<LineRenderer> ();
	}
	
	// TODO clean code
	void Update () {
		Physics.Raycast (transform.position, transform.forward, out hit);
		Vector3[] positions = { transform.position, hit.point };
		line.SetPositions (positions);

		if (Input.GetMouseButton(0)) {
			if (gameC.Phase == GameController.GamePhase.CONSTRUCTION) {
				if (Physics.Raycast(transform.position, transform.forward, out hit)) {
					// Check hit object (ui or cell)
					VRButtonInteractionController buttonController = hit.collider.GetComponent<VRButtonInteractionController>();
					CellController cell = hit.collider.GetComponent<CellController>();
					VRPlayButtonController playButtonController = hit.collider.GetComponent<VRPlayButtonController>();

					if (buttonController != null) {
						Color buttonColor = buttonController.TriggeredHandler();
						constructionGui.ActualizeSelectedBlock (buttonColor);
					} else if (cell != null)  {
						gameC.DoTriggerAction(cell);
					} else if (playButtonController != null) {
						playButtonController.TriggeredHandler();
					}
				}
			} else {
				RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward);
				bool buttonClicked = false;

				foreach (RaycastHit hit in hits) {
					VRBackToMenuButton backButton = hit.collider.GetComponent<VRBackToMenuButton>();

					if (backButton != null) {
						backButton.TriggerPressedHandler();
					}
				}

				if (!buttonClicked) { 
					gameC.DoTriggerAction(transform.forward);
				}
			}
		} else if (Input.GetMouseButton(1) && gameC.Phase == GameController.GamePhase.CONSTRUCTION) {
			RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward);

			foreach (RaycastHit hitInfo in hits)
			{
				CellController cell = hitInfo.collider.GetComponent<CellController>();

				if (cell != null)
				{
					cell.EmptyCell();
				}
			}
		}
	}
}
