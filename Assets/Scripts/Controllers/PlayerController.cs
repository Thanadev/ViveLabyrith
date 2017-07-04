using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
	public GameObject cameraObject;
	public float speedFactor = 100;

	Rigidbody rb;
    Vector3 nextVelocity;

	void Awake () {
		rb = GetComponent<Rigidbody> ();
	}

    public void TriggeredMoveHandler (Vector3 direction)
    {
        direction.y = 0;
        rb.velocity = direction.normalized * Time.deltaTime * speedFactor;
    }
}
