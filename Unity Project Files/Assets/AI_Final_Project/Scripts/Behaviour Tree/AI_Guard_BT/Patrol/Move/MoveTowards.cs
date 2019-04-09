using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveTowards : Node
{
    GuardBlackboard m_guardBlackboard;
    NavMeshAgent m_agent;

    public MoveTowards(ref GuardBlackboard guardBlackboard, ref NavMeshAgent agent)
    {
        m_guardBlackboard = guardBlackboard;
        m_agent = agent;
    }

    public override Status Run()
    {
        //if (m_guardBlackboard.m_destination != m_agent.destination)
        //{
        //    return NodeStates.RUNNING;
        //}

        m_agent.SetDestination(m_guardBlackboard.m_destination);

        //m_agent.destination = m_guardBlackboard.m_destination;
        return Status.SUCCESS;
    }
}
