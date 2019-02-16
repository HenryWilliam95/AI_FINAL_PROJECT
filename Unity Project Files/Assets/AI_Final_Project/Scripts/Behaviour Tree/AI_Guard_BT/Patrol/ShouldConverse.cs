using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShouldConverse : Node
{
    public GameObject[] nearbyAgents;

    public NavMeshAgent m_agent;
    public GuardBlackboard m_guardBlackboard;

    public ShouldConverse(ref GuardBlackboard guardBlackboard, ref NavMeshAgent agent)
    {
        m_agent = agent;
        m_guardBlackboard = guardBlackboard;

    }

    public override Status Run()
    {
        // Stop the agents
        m_agent.isStopped = true;
        m_guardBlackboard.converseAgent.GetComponent<NavMeshAgent>().isStopped = true;

        // Make them look at each other
        m_guardBlackboard.converseAgent.gameObject.transform.LookAt(this.m_guardBlackboard.gameObject.transform);
        m_guardBlackboard.gameObject.transform.LookAt(m_guardBlackboard.converseAgent.gameObject.transform);

        // Perform some kind of action

        // Resume On path



        return Status.SUCCESS;
    }
}
