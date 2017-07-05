using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRBackToMenuButton : MonoBehaviour {

	public void TriggerPressedHandler()
    {
        SceneManager.LoadScene("menu");
    }
}
