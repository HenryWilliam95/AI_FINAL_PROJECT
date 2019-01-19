using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour {

    public Transform[] patrolLocations;
    public int destination = 0;
    private NavMeshAgent agent;

    Node behaviourTree;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        destination = Random.Range(0, patrolLocations.Length);
        StartCoroutine("PatrolPath");
	}
	
	// Update is called once per frame
	void Update () {
        if (!agent.pathPending && agent.remainingDistance < 0.5)
        {
            agent.isStopped = true;
            agent.ResetPath();

            StartCoroutine("PatrolPath");
        }
        else
        {
            StopCoroutine("PatrolPath");
        }
    }

    IEnumerator PatrolPath()
    {
        int waitTime = Random.Range(2,6);
        yield return new WaitForSeconds(waitTime);

        agent.destination = patrolLocations[destination].position;
        destination = Random.Range(0, patrolLocations.Length);
    }
}
