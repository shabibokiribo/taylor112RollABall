//////////////////////////////////////////////////////
// Assignment/Lab/Project: RollABall Asignment
//Name: Shaniah Taylor
//Section: 2022FA.SGD.113.2602
//Instructor: Lydia Granholm
// Date: 09/19/2023
//////////////////////////////////////////////////////
using System.Collections;
using System.Collections.Generic;
//////////////////////////////////////////////////////
// Assignment/Lab/Project: 112RollABall
//Name: Shaniah Taylor
//Section: 2022FA.SGD.112.2602
//Instructor: Lydia Granholm
// Date: 10/28/2023
//////////////////////////////////////////////////////
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    public PlayerController psCon;

    //gameobject variable to assign projectile prefab in unity & player game object
    public GameObject projectile;

    public GameObject player;

    //Transform object to go ake player the target
    private Transform playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTarget = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //destory projectile after 10 seconds
        Destroy(projectile, 10);

        var step = 5.0f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, step);

    }

}
