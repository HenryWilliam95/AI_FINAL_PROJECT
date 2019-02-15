using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBlackboard : MonoBehaviour
{
    public Vector3 lastPlayerSighting;

    public GuardBlackboard[] guardBlackboards;

    private void Awake()
    {
        lastPlayerSighting = new Vector3(1000, 1000, 1000);

        guardBlackboards = FindObjectsOfType<GuardBlackboard>();
    }
}
