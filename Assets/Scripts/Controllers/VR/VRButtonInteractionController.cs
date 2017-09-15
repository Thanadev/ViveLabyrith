using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRButtonInteractionController : MonoBehaviour {

    public int blockIndex;

    private BlockService blockS;
	private Image img;

    void Awake ()
    {
        blockS = FindObjectOfType<BlockService>();
		img = GetComponent<Image> ();
    }

	public Color TriggeredHandler ()
    {
        blockS.SelectBlock(blockIndex);

		return img.color;
    }
}
