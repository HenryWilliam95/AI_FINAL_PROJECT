﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttemptConversation : Node
{
    GuardBlackboard guardBlackboard;

    public AttemptConversation(ref GuardBlackboard _guardBlackboard)
    {
        guardBlackboard = _guardBlackboard;
    }

    public override Status Run()
    {
        if (guardBlackboard.GetTriedToConverse() == true)
        {
            return Status.FAILURE;
        }

        return Status.SUCCESS;
    }
}
