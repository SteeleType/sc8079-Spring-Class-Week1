using System;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class WASDController : MonoBehaviour
{
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;

    public Rigidbody rb;

    public float moveForce = 10f;

    public Vector3 testVec;
    public Vector3 adjacentVec;
    public Vector3 startPos;
    float speed;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("START!!!");
        
        startPos = transform.position;

    }


    void OnTriggerEnter(Collider other)
    {
    
        if (other.CompareTag("KillZone"))
        {
            transform.position = startPos;
            Debug.Log("HIT");
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
        if ((other.CompareTag("Zone")) && (gameObject.GetComponent<Rigidbody>().linearVelocity == Vector3.zero))
        {
            Debug.Log("SCORE");
        }
        
    }

    // Update is called once per frame
    void Update()
    
    {
        speed = rb.linearVelocity.magnitude;
        if (Input.GetKey(keyUp))
        {
            rb.AddForce(testVec * moveForce);
     
        }
        if (Input.GetKey(keyDown))
        {
            rb.AddForce(testVec * -moveForce);
        }
        if (Input.GetKey(keyLeft))
        {
            rb.AddForce(adjacentVec * -moveForce);
        }
        if (Input.GetKey(keyRight))
        {
            rb.AddForce(adjacentVec * moveForce);
        }
    }
}
