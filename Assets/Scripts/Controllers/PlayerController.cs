using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	public GameObject cameraObject;

	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		Vector3 nextVelocity = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		
		rb.velocity = nextVelocity;
	}
}
