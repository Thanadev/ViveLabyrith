using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	public float speedFactor = 100;

	Rigidbody rb;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		TriggeredMoveHandler (new Vector3 (Input.GetAxisRaw ("Horizontal"), 0, Input.GetAxisRaw ("Vertical")));
	}

    public void TriggeredMoveHandler (Vector3 direction) {
        direction.y = 0;
		rb.velocity = transform.TransformDirection(direction.normalized) * Time.deltaTime * speedFactor;
    }
}
