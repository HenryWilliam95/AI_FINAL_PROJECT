using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardBlackboard : MonoBehaviour
{
    // AI States
    public enum GuardState { patrolling, hunting, conversing }
    private GuardState guardstate;

    // Player Sighting
    public Vector3 m_playerLastSighting;
    public bool m_playerInSight;

    // Movement
    public Vector3 m_destination;
    public string m_patrolPoints;

    // Conversations
    private float converseTimer = 0;
    private bool finishedConversation = false;
    private bool triedToConverse = false;
    public GameObject converseAgent;

    private void Update()
    {
        if (triedToConverse == true)
        {
            ConversationTime();
        }
    }

    public void ConversationTime()
    {
        if (converseTimer <= 0)
        {
            triedToConverse = false;
            converseTimer = 5f;
            return;
        }

        converseTimer -= Time.deltaTime;
    }

    private IEnumerator ConversationWait(int seconds)
    {
        SetFinishedConversation(false);

        yield return new WaitForSeconds(seconds);

        SetFinishedConversation(true);
        Debug.Log("Finished Conversation = " + finishedConversation);
    }

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
            converseTimer = 5f;
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
    #endregion
}
