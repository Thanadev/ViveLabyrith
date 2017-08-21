using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	void Update () {
		Vector3 rotation = new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);
		rotation += transform.rotation.eulerAngles;
		transform.rotation = Quaternion.Euler (rotation);

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
}
