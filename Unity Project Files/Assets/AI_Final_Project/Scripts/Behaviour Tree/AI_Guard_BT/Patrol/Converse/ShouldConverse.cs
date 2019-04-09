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
        // Stop the agent and cause them to look at each other, and update their state
        m_agent.isStopped = true;
        
        m_guardBlackboard.SetGuardState(GuardBlackboard.GuardState.conversing);

        if (m_guardBlackboard.GetGuardState() == GuardBlackboard.GuardState.conversing)
        {
            m_guardBlackboard.gameObject.transform.LookAt(m_guardBlackboard.converseAgent.gameObject.transform);
        }

        // Perform some kind of action
        if (m_guardBlackboard.GetFinishedConversation() == false)
        {
            Debug.Log("Starting Coroutine for " + m_guardBlackboard.gameObject.name);
            m_guardBlackboard.StartCoroutine("ConversationWait", 4);
        }
        

        // If the conversation is finished resume on path
        if (m_guardBlackboard.GetFinishedConversation() == true)
        {
            Debug.Log(m_guardBlackboard.thisObject.name + " returned to patrolling");
            m_agent.isStopped = false;
            m_agent.destination = m_guardBlackboard.m_destination;
            m_guardBlackboard.SetGuardState(GuardBlackboard.GuardState.patrolling);
            m_guardBlackboard.converseAgent = null;
            m_guardBlackboard.SetTriedToConverse(true);
            m_guardBlackboard.SetFinishedConversation(false); 
            return Status.SUCCESS;
        }

        return Status.RUNNING;
  
    }

    
}
