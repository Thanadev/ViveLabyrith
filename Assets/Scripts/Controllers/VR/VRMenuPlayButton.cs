using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRMenuPlayButton : MonoBehaviour {

	public void StartGame () {
		SceneManager.LoadScene ("main");
	}
}
