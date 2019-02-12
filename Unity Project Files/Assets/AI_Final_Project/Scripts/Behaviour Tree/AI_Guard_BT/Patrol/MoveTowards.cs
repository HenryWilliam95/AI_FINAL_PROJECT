using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowards : Leaf
{
    GuardBlackboard m_guardBlackboard;
    NavMeshAgent m_agent;

    public MoveTowards(ref GuardBlackboard guardBlackboard, ref NavMeshAgent agent)
    {
        m_guardBlackboard = guardBlackboard;
        m_agent = agent;
    }

    public override NodeStates Run()
    {
        //if (m_guardBlackboard.m_destination != m_agent.destination)
        //{
        //    return NodeStates.RUNNING;
        //}

        Debug.Log("Moving towards Location");

        m_agent.destination = m_guardBlackboard.m_destination;
        return NodeStates.SUCCESS;
    }
}
