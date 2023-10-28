//////////////////////////////////////////////////////
// Assignment/Lab/Project: 112RollABall
//Name: Shaniah Taylor
//Section: 2022FA.SGD.112.2602
//Instructor: Lydia Granholm
// Date: 10/28/2023
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

	
	void Start ()
    {
        offset = transform.position - player.transform.position;
	}
	
	
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;
	}
}
