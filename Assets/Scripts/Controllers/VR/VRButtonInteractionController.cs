using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRButtonInteractionController : MonoBehaviour {

    public int blockIndex;

    private BlockService blockS;

    void Awake ()
    {
        blockS = FindObjectOfType<BlockService>();
    }

    public void TriggeredHandler ()
    {
        blockS.SelectBlock(blockIndex);
    }
}
