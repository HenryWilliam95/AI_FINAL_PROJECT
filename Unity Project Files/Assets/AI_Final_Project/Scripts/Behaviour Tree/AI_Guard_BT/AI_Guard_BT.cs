﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Guard_BT : MonoBehaviour
{
    Node behaviourTree;

    [SerializeField]    GuardBlackboard guardBlackboard;
    [SerializeField]    NavMeshAgent agent;

	// Use this for initialization
	void Awake ()
    {     
        guardBlackboard = GetComponent<GuardBlackboard>();
        agent = GetComponent<NavMeshAgent>();
        behaviourTree = InitializeBahaviourTree();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        behaviourTree.Run();
	}

    Node InitializeBahaviourTree()
    {
        Sequence patrol = new Sequence("patrol",
            new PickLocation(ref guardBlackboard, ref agent),
            new MoveTowards(ref guardBlackboard, ref agent));

        Selector idle = new Selector("idle",
            patrol);

        Selector root = new Selector("root",
            idle);

        return root;
    }
}