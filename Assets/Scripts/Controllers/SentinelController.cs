using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class SentinelController : MonoBehaviour {
    public float timeBeforeHunt = 5f;

    private bool hunting = false;
    private Transform player;
    private NavMeshAgent nav;

	// Use this for initialization
	void Awake () {
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
		if (hunting)
        {
            nav.SetDestination(player.position);
        }
	}

    public void GameLaunchHandler ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(StartHuntingPlayer());
    }

    IEnumerator StartHuntingPlayer ()
    {
        yield return new WaitForSeconds(timeBeforeHunt);
        hunting = true;
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("COOOOOOOOOCOCOCOCO " + other.name);
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("menu");
        }
    }
}
