using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalBlackboard : MonoBehaviour
{
    public Vector3 lastPlayerSighting;

    private void Awake()
    {
        lastPlayerSighting = new Vector3(1000, 1000, 1000);
    }
}
