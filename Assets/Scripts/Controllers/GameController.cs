using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour {

    public GameObject constructionCameraContainer;
	public Camera constructionCamera;
	public BlockService blockS;
	public ConstructionGuiController constructionGui;
    public NavMeshSurface terrain;

    private GamePhase phase;
	private Ray mouseRay;
	private RaycastHit cellHit;
	private CellController selectedCell;
    private PlayerController playerController;

	// Use this for initialization
	void Awake () {
		phase = GamePhase.CONSTRUCTION;
	}
	
	// Update is called once per frame
	void Update () {
        // Mouse controls
		if (phase == GamePhase.CONSTRUCTION) {
			if (Input.GetMouseButton (0)) {
				selectedCell = null;
				GetSelectedCell ();

                DoTriggerAction(selectedCell);
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

    public void DoTriggerAction (CellController cell)
    {
        if (phase == GamePhase.CONSTRUCTION)
        {
            selectedCell = cell;

            if (selectedCell != null)
            {
                if (blockS.CanPlaceCurrentBlock())
                {
                    selectedCell.SetBlock(blockS.CurrentBlock);

                    if (blockS.CurrentBlock.CompareTag("PlayerSpawn"))
                    {
                        blockS.SpawnPlaced = true;
                    }
                }
            }
        }
    }

    public void DoTriggerAction(Vector3 direction)
    {
        if (phase == GamePhase.PLAY)
        {
            playerController.TriggeredMoveHandler(direction);
        }
    }

    public void LaunchGame () {
        // Cells
        CellController[] cells = FindObjectsOfType<CellController>();
        terrain.BuildNavMesh();

        foreach (CellController cell in cells) {
			cell.HidePlaceholder ();
		}

        // Disappearing objects
		DisappearOnLaunchController[] toDisappear = FindObjectsOfType<DisappearOnLaunchController> ();
		foreach (DisappearOnLaunchController dis in toDisappear) {
			dis.Disappear ();
		}

        // Spawn Player
		playerController = FindObjectOfType<PlayerSpawnController> ().SpawnPlayer ();

        // Sentinels
        SentinelController[] sentinels = FindObjectsOfType<SentinelController>();
        foreach (SentinelController sentinel in sentinels)
        {
            sentinel.GameLaunchHandler();
        }

        // End the construction phase
        constructionGui.HideConstructionElement();
        constructionCameraContainer.SetActive(false);
        constructionCamera.gameObject.SetActive (false);
        phase = GamePhase.PLAY;
    }

	private void GetSelectedCell () {
		mouseRay = constructionCamera.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (mouseRay, out cellHit)) {
			selectedCell = cellHit.collider.GetComponent<CellController> ();
		}
	}

    public GamePhase Phase
    {
        get
        {
            return phase;
        }
    }

	public enum GamePhase {
		CONSTRUCTION, 
		PLAY
	};
}
