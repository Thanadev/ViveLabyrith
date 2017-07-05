using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VRMenuPlayButton : MonoBehaviour {

    public float secondsBeforeActivation = 1f;

    void Awake ()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Button>().interactable = false;
    }

    void Start ()
    {
        StartCoroutine(TimerForActivation());
    }

	public void StartGame () {
		SceneManager.LoadScene ("main");
	}

    private IEnumerator TimerForActivation ()
    {
        yield return new WaitForSeconds(secondsBeforeActivation);

        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Button>().interactable = true;
    }
}
