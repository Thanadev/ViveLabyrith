using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	public GameObject cameraObject;
	public float speedFactor = 100;

	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		Vector3 nextVelocity = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		nextVelocity = transform.TransformDirection (nextVelocity);
		rb.velocity = nextVelocity * Time.deltaTime * speedFactor;

		Vector3 nextEuler = transform.rotation.eulerAngles;
		nextEuler.y += Input.GetAxisRaw ("Mouse X");
		nextEuler.x += Input.GetAxisRaw ("Mouse Y") * -1;

		transform.rotation = Quaternion.Euler (nextEuler);
	}
}
