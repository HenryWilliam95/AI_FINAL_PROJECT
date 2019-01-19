using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    public float m_fieldOfViewAngle = 110f;  // Number of degrees the enemy can see on Vector3.Forward
    [SerializeField] private GameObject player;

    private SphereCollider sphereCollider;
    private Vector3 lastKnownPosition;
    private GuardBlackboard guardBlackboard;   
    private GlobalBlackboard globalBlackboard;

    private void Awake()
    {
        guardBlackboard = GetComponent<GuardBlackboard>();
        globalBlackboard = GetComponent<GlobalBlackboard>();
        guardBlackboard.m_playerInSight = false;

        sphereCollider = GetComponent<SphereCollider>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        // If the player is spoted by one of the guards, move all other guards to location
        guardBlackboard.m_playerLastSighting = globalBlackboard.lastPlayerSighting;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            // If the player is in the guards sight but objects are in the way, guard cannont see.
            guardBlackboard.m_playerInSight = false;

            // Create a vector in the direction of the player, this can then be compared using Vector3.Angle to see if the player is within the field of view
            Vector3 vectorToPlayer = other.transform.position - transform.position;
            float angle = Vector3.Angle(vectorToPlayer, transform.forward);

            // If the player is within half of the view angle, they are in sight
            if (angle < m_fieldOfViewAngle * 0.5)
            {
                RaycastHit hit;

                // Exclude the enemy layer from the raycast
                int layerMask = 1 << 10;
                layerMask = ~layerMask;
                
                // Send the ray only as far as the sphere collider and only check for the player's layer
                if (Physics.Raycast((transform.position + Vector3.up), vectorToPlayer, out hit, sphereCollider.radius, layerMask))
                {
                    Debug.Log("Hit: " + hit.collider.name);
                    Debug.DrawRay(transform.position + Vector3.up, vectorToPlayer, Color.green);

                    if (hit.collider.gameObject == player)
                    {
                        guardBlackboard.m_playerInSight = true;
                        guardBlackboard.m_playerLastSighting = other.transform.position;

                        globalBlackboard.lastPlayerSighting = other.transform.position;
                    }
                    else
                    {
                        guardBlackboard.m_playerInSight = false;
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            guardBlackboard.m_playerInSight = false;
        }
    }
}
