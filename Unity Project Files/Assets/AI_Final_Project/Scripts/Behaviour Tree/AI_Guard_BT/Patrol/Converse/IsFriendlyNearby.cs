using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFriendlyNearby : Node {

    GuardBlackboard guardBlackboard;
    GlobalBlackboard globalBlackboard;

    public IsFriendlyNearby(ref GuardBlackboard _guardBlackboard, ref GlobalBlackboard _globalBlackboard)
    {
        guardBlackboard = _guardBlackboard;
        globalBlackboard = _globalBlackboard;
    }

    public override Status Run()
    {
        for (int i = 0; i < globalBlackboard.guardBlackboards.Length; i++)
        {
            if (globalBlackboard.guardBlackboards[i] == guardBlackboard)
            {
                continue;
            }

            // Loop through all AI seeing if any are close
            if (guardBlackboard.GetDistance(globalBlackboard.guardBlackboards[i].GetPosition()) < 5f)
            {
                // If a guard is close, and in conversation
                if (globalBlackboard.guardBlackboards[i].GetGuardState() == GuardBlackboard.GuardState.conversing)
                {
                    Debug.Log("Converse");
                    // If the AI is conversing with another agent, move on and reset timers
                    if (globalBlackboard.guardBlackboards[i].converseAgent != this.guardBlackboard.gameObject)
                    {
                        guardBlackboard.SetTriedToConverse(true);
                        return Status.FAILURE;
                    }
                }

                guardBlackboard.converseAgent = globalBlackboard.guardBlackboards[i].gameObject;
                return Status.SUCCESS;
            }
        }
        return Status.FAILURE;
    }
}
