using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRController : MonoBehaviour {

    private SteamVR_TrackedController controller;
    private GameController gameC;
    private RaycastHit hit; 

    // Use this for initialization
    void Start () {
        controller = GetComponent<SteamVR_TrackedController>();
        gameC = FindObjectOfType<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.triggerPressed) {
            if (gameC.Phase == GameController.GamePhase.CONSTRUCTION)
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit)) {
                    // Check hit object (ui or cell)
                    VRButtonInteractionController buttonController = hit.collider.GetComponent<VRButtonInteractionController>();
                    CellController cell = hit.collider.GetComponent<CellController>();
                    VRPlayButtonController playButtonController = hit.collider.GetComponent<VRPlayButtonController>();

                    if (buttonController != null)
                    {
                        buttonController.TriggeredHandler();
                    } else if (cell != null)  {
                        gameC.DoTriggerAction(cell);
                    } else if (playButtonController != null) {
                        playButtonController.TriggeredHandler();
                    }
                }
            } else {
                RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward);
                bool buttonClicked = false;

                foreach (RaycastHit hit in hits)
                {
                    VRBackToMenuButton backButton = hit.collider.GetComponent<VRBackToMenuButton>();

                    if (backButton != null)
                    {
                        backButton.TriggerPressedHandler();
                    }
                }

                if (!buttonClicked) { 
                    gameC.DoTriggerAction(transform.forward);
                }
            }
        } else if (controller.padPressed && gameC.Phase == GameController.GamePhase.CONSTRUCTION) {
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
