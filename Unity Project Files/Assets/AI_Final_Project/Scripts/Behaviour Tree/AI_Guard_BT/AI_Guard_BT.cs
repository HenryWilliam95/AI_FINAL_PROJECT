using System.Collections;
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
        #region IDLE BEHAVIOURS
        Sequence patrol = new Sequence("patrol",
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

        /*Sequence shouldConverse = new Sequence("shouldConverse",
            IsAnotherGuardNear,
            MoveTowards,
            Converse);*/
        #endregion

        #region ENGAGE BEHAVIOURS

        #endregion

        Selector idle = new Selector("idle",
            //shouldConverse,
            //needs,
            patrol);

        Selector root = new Selector("root",
            idle);

        return root;
    }
}
