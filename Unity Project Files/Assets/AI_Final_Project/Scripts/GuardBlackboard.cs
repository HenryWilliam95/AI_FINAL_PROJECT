using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBlackboard : MonoBehaviour
{
    public Vector3 m_playerLastSighting;
    public bool m_playerInSight;

    public Vector3 m_destination;
    public string m_patrolPoints;

    public GameObject converseAgent;

    private void Start()
    {

    }

    public Vector3 GetPosition()
    {
        return this.transform.position;
    }

    public float GetDistance(Vector3 guard)
    {
        return Vector3.Distance(this.transform.position, guard);
    }
}
