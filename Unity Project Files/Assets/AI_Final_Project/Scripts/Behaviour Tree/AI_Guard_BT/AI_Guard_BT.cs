using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Guard_BT : MonoBehaviour
{
    Node behaviourTree;

    [SerializeField]    GuardBlackboard guardBlackboard;
    [SerializeField]    GlobalBlackboard globalBlackboard;
    [SerializeField]    NavMeshAgent agent;

	// Use this for initialization
	void Awake ()
    {     
        guardBlackboard = GetComponent<GuardBlackboard>();
        globalBlackboard = FindObjectOfType<GlobalBlackboard>();
        agent = GetComponent<NavMeshAgent>();
        behaviourTree = InitializeBahaviourTree();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        behaviourTree.Run();
	}

    Node InitializeBahaviourTree()
    {
        #region IDLE BEHAVIOURS
        SequenceNode patrol = new SequenceNode("patrol",
            new PickLocation(ref guardBlackboard, ref agent),
            new MoveTowards(ref guardBlackboard, ref agent));

        /*Sequence tired = new Sequence("tired",
            AmITired,
            FindBed,
            Sleep);*/

        /*Sequence thirsty = new Sequence("thirsty,"
            AmIThirsty,
            FindDrink,
            Drink);*/

        /*Sequence hungry = new Sequence("Hungry,"
            AmIHungry,
            FindFood,
            Eat); */

        /*Selector needs = new Selector("needs",
            hungry,
            thirsty,
            tired);*/

        SequenceNode shouldConverse = new SequenceNode("shouldConverse",
            new IsFriendlyNearby(ref guardBlackboard, ref globalBlackboard));
        #endregion

        #region ENGAGE BEHAVIOURS

        #endregion

        SelectorNode idle = new SelectorNode("idle",
            shouldConverse,
            //needs,
            patrol);
            

        SelectorNode root = new SelectorNode("root",
            idle);

        return root;
    }
}
