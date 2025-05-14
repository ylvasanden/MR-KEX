using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTEST : MonoBehaviour
{
    public GameObject prefab;
    public float spawnSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {   
            GameObject spawnedBall = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody spawnedBallRB = spawnedBall.GetComponent<Rigidbody>();
            spawnedBallRB.linearVelocity = transform.forward * spawnSpeed;
        } 
    }
}
