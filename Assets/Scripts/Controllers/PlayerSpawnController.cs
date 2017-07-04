using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour {

	public GameObject playerPrefab;

	public PlayerController SpawnPlayer () {
        GameObject player;
		player = Instantiate (playerPrefab, new Vector3 (transform.position.x, playerPrefab.transform.position.y, transform.position.z), playerPrefab.transform.rotation) as GameObject;

        return player.GetComponent<PlayerController>();
    }
}
