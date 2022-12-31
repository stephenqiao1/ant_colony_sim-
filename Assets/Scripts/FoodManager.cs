using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public int numFoods = 50;
    public GameObject foodSource;
    void Start()
    {
        for (int i=0; i < numFoods; i++) {
            Vector3 spawnPos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-5.0f, 5.0f), 0); 
            Instantiate(foodSource, spawnPos, foodSource.transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
