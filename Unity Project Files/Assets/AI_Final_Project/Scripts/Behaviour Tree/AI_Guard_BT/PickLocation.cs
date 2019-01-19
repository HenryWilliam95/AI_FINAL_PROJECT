using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PickLocation : Leaf
{
    GameObject[] patrolLocations;
    GuardBlackboard m_guardBlackboard;
    NavMeshAgent m_agent;

    public PickLocation(ref GuardBlackboard guardBlackboard, ref NavMeshAgent agent)
    {
        m_guardBlackboard = guardBlackboard;
        m_agent = agent;
        patrolLocations = GameObject.FindGameObjectsWithTag(m_guardBlackboard.m_patrolPoints);
    }

    public override NodeStates Run()
    {
        // if there are no locations found, then exit out
        if (patrolLocations == null)
        {
            return NodeStates.FAILURE;
        }

        // If the agent is still traveling to the location do not reassign
        if (m_agent.remainingDistance > 0.6)
        {
            return NodeStates.SUCCESS;
        }

        // If the agent is close to the destination 
        if (m_agent.remainingDistance < 0.5)
        {
            // Pick a random point from the patrol waypoints and parse that into the guards blackboard to be used with other behaviours
            int dest = Random.Range(0, patrolLocations.Length);
            m_guardBlackboard.m_destination = patrolLocations[dest].transform.position;
        }
        return NodeStates.SUCCESS;
    }


}
