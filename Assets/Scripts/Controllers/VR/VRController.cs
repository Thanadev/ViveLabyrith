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
        //controller.TriggerClicked += TriggerPressedHandler;
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.triggerPressed)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                // Check hit object (ui or cell)
                VRButtonInteractionController buttonController = hit.collider.GetComponent<VRButtonInteractionController>();

                if (buttonController != null)
                {
                    buttonController.TriggeredHandler();
                }
                else
                {
                    CellController cell = hit.collider.GetComponent<CellController>();

                    if (cell != null)
                    {
                        gameC.DoPlaceAction(cell);
                    }
                }
            }
        } else if (controller.padPressed)
        {
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
