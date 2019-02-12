using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickLocation : Leaf
{
    GameObject[] patrolLocations;
    GuardBlackboard m_guardBlackboard;
    NavMeshAgent m_agent;

    int dest;

    public PickLocation(ref GuardBlackboard guardBlackboard, ref NavMeshAgent agent)
    {
        m_guardBlackboard = guardBlackboard;
        m_agent = agent;
        patrolLocations = GameObject.FindGameObjectsWithTag(m_guardBlackboard.m_patrolPoints);

        dest = Random.Range(0, patrolLocations.Length);
        m_guardBlackboard.m_destination = patrolLocations[dest].transform.position;
    }

    public override NodeStates Run()
    {
        //Debug.Log(dest);
        // if there are no locations found, then exit out
        if (patrolLocations == null)
        {
            return NodeStates.FAILURE;
        }

        Debug.Log("Picking Location");

        // If the agent is still traveling to the location do not reassign
        if (m_agent.remainingDistance > 0.6)
        {
            return NodeStates.SUCCESS;
        }

        // If the agent is close to the destination 
        if (m_agent.remainingDistance < 0.5)
        {
            // Pick a random point from the patrol waypoints and parse that into the guards blackboard to be used with other behaviours
            dest = Random.Range(0, patrolLocations.Length);
            m_guardBlackboard.m_destination = patrolLocations[dest].transform.position;
        }
        return NodeStates.SUCCESS;
    }
}
