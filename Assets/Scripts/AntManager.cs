using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntManager : MonoBehaviour
{
    public int numAnts = 10;
    public GameObject antSource;
    void Start()
    {
        for (int i=0; i < numAnts; i++) {
            Vector3 spawnPos = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-5.0f, 5.0f), 0); 
            Instantiate(antSource, spawnPos, antSource.transform.rotation);
        }
    }

    void Update()
    {
        
    }
}
