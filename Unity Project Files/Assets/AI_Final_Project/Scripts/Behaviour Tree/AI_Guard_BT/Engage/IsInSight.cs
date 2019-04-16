using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsInSight : Node
{
    GuardBlackboard guardblackboard;

    public IsInSight(GuardBlackboard _guardblackboard)
    {
        guardblackboard = _guardblackboard;
    }

    public override Status Run()
    {
        if(guardblackboard.m_playerInSight)
        {
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }
}
