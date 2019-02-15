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
                break;
            }

            if (guardBlackboard.GetDistance(globalBlackboard.guardBlackboards[i].GetPosition()) < 5f)
            {
                Debug.Log(guardBlackboard.name + " is close to: " + globalBlackboard.guardBlackboards[i].name);
                return Status.SUCCESS; 
            }

        }
        return Status.FAILURE;
    }
}
