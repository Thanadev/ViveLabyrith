using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class DisappearOnLaunchController : MonoBehaviour {

	public void Disappear () {
		GetComponent<MeshRenderer> ().enabled = false;
	}
}
