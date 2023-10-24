using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class FoodTower : MonoBehaviour
{

    int foodNum;
    public List<GameObject> food;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("LaunchProjectile", 1.0f, 3.0f);
        foodNum = Random.RandomRange(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaunchProjectile()
    {
        GameObject instance = Instantiate(food[foodNum], transform.position, Quaternion.identity);
        instance.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere * 10.0f;
    }
}
