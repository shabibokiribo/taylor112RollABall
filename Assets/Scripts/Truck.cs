using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public GameObject projectile;
    //public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(projectile, 10);
    }

    // Update is called once per frame
    void Update()
    {
        //var step = 5.0f * Time.deltaTime;
       //projectile.transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }
}
