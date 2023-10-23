using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckTower : MonoBehaviour
{
    public GameObject projectile;
    public GameObject tower;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchProjectile()
    {
        Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
       // GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
       // instance.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * 5.0f;
    }
}
