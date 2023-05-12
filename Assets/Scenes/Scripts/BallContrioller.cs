using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallContrioller : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();

        myRigidbody.velocity = new Vector3(speed, speed, speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
