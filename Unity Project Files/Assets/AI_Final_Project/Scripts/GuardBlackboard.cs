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

    public GameObject[] activeAgents;
    public AI_Guard_BT[] aI_Guard_BTs;

    private void Start()
    {
        aI_Guard_BTs = GetComponents<AI_Guard_BT>();

        int i = 0;
        foreach (AI_Guard_BT item in aI_Guard_BTs)
        {
            activeAgents[i] = item.gameObject;
            i++;
        }
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
