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
        //int i = 0;
        //foreach (var agent in m_guardBlackboard.activeAgents)
        //{
        //    if (Vector3.Distance(m_agent.gameObject.transform.position, agent.transform.position) > 2f)
        //    {
        //        Debug.Log(agent.name + " is near " + agent.name);
        //        return NodeStates.SUCCESS;
        //    }
        //}

        return Status.FAILURE;
    }

}
