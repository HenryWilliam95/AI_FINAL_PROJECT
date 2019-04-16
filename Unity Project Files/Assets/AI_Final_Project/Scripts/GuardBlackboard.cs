using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBlackboard : MonoBehaviour
{
    // AI States
    public enum GuardState { patrolling, hunting, conversing }
    public GuardState guardstate;

    // Player Sighting
    public Vector3 m_playerLastSighting;
    public bool m_playerInSight;

    // Movement
    public Vector3 m_destination;
    public string m_patrolPoints;
    public float wanderTimer;

    public GameObject thisObject;

    // Conversations
    private const float CONVERSATION_RETY_TIMER = 10f;
    private float converseTimer = 0;
    private bool finishedConversation = false;
    public bool triedToConverse = false;
    public GameObject converseAgent;

    public GlobalBlackboard globalBlackboard;

    private void Start()
    {
        globalBlackboard = FindObjectOfType<GlobalBlackboard>();
        thisObject = gameObject;
    }

    private void Update()
    {
        if (triedToConverse == true)
        {
            ConversationTime();
        }

        wanderTimer += Time.deltaTime;
    }

    public void ConversationTime()
    {
        if (converseTimer <= 0)
        {
            triedToConverse = false;
            converseTimer = CONVERSATION_RETY_TIMER;
            return;
        }

        converseTimer -= Time.deltaTime;
    }

    private IEnumerator ConversationWait(int seconds)
    {
        SetFinishedConversation(false);

        yield return new WaitForSeconds(seconds);

        SetFinishedConversation(true);
        Debug.Log(gameObject.name + " Finished Conversation = " + finishedConversation);
    }

    //public void OnDrawGizmos()
    //{
    //    Gizmos.DrawWireSphere(gameObject.transform.position, 30);
    //}

    #region Getter&Setter

    public GuardState GetGuardState()
    {
        return guardstate;
    }

    public void SetGuardState(GuardState state)
    {
        guardstate = state;
    }

    public bool GetFinishedConversation()
    {
        return finishedConversation;
    }

    public void SetFinishedConversation(bool conversationOver)
    {
        finishedConversation = conversationOver;
    }

    public bool GetTriedToConverse()
    {
        return triedToConverse;
    }

    public void SetTriedToConverse(bool conversation)
    {
        triedToConverse = conversation;

        if (triedToConverse == true)
        {
            converseTimer = CONVERSATION_RETY_TIMER;
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

    public GuardBlackboard[] GetGuardBlackboard()
    {
        return globalBlackboard.guardBlackboards;
    }
    #endregion
}
