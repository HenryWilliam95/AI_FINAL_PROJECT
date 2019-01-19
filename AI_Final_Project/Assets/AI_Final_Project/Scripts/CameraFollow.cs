using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    private Vector3 rotation;

	// Use this for initialization
	void Start ()
    {
        rotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        transform.position = player.transform.position;

        if (Input.GetKey(KeyCode.L))
        {
            rotation.y++;

            transform.rotation = Quaternion.Euler(rotation);
        }
        else if (Input.GetKey(KeyCode.K))
        {
            rotation.y--;

            transform.rotation = Quaternion.Euler(rotation);
        }
	}
}
