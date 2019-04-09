using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wander : Node
{
    GuardBlackboard guardBlackboard;
    NavMeshAgent agent;

    private Vector3 nextDestination;

    private float wanderTimer = 10f;
    public float wanderRadius = 30f;
    public float timer;

    public Wander(ref GuardBlackboard _guardBlackboard, ref NavMeshAgent _agent)
    {
        guardBlackboard = _guardBlackboard;
        agent = _agent;
        
    }

    public override void OnStart()
    {
        guardBlackboard.m_destination = RandomNavPoint(guardBlackboard.thisObject.transform.position, wanderRadius, agent.areaMask);
        timer = 0;
    }

    public override Status Run()
    {
        if(DestinationReached())
        {
            guardBlackboard.m_destination = RandomNavPoint(guardBlackboard.thisObject.transform.position, wanderRadius, agent.areaMask);

            return Status.SUCCESS;
        }

        if(guardBlackboard.wanderTimer >= wanderTimer)
        {
            guardBlackboard.m_destination = RandomNavPoint(guardBlackboard.thisObject.transform.position, wanderRadius, agent.areaMask);
            Debug.Log(timer);
            timer = 0f;
            return Status.SUCCESS;
        }

        if(agent.pathStatus == NavMeshPathStatus.PathInvalid)
        {
            guardBlackboard.m_destination = RandomNavPoint(guardBlackboard.thisObject.transform.position, wanderRadius, agent.areaMask);

            return Status.SUCCESS;
        }

        return Status.SUCCESS;
    }

    private Vector3 RandomNavPoint(Vector3 _origin, float _dist, int _layerMask)
    {
        Vector3 randDirection = Random.insideUnitSphere * _dist;
        randDirection += _origin;

        NavMeshHit navHit;

        if(NavMesh.SamplePosition(randDirection, out navHit, _dist, _layerMask))
        {
            return navHit.position;
        }
        else
        {
            return RandomNavPoint(_origin, _dist, _layerMask);
        }
    }

    private bool DestinationReached()
    {
        return Vector3.Distance(guardBlackboard.thisObject.transform.position, nextDestination) < 1f;
    }

}
