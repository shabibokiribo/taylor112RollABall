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

public class towerScript : MonoBehaviour
{
    //#6
    //projectile declaring
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        //invoke repeating to make projectile launch every 1 seconds after the first one launches after 1 second
        InvokeRepeating("LaunchProjectile", 2.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //method so we can call launch in invokerepeating above. instantiates projectile from tower.
    void LaunchProjectile()
    {
        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
        instance.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * 5.0f;
    }
}
