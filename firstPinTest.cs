using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPinTest : MonoBehaviour
{
    public bool topPin;
    public float rotationSpeed = 0.1f;
    public Vector3 rot;
    public float rotationFloat;
    public float movementFloat;
    public Vector3 lockPinRotation;
    public int maxAngle;



    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame  
    void Update()
    {
       
    
        rotationFloat = Input.GetAxis("Horizontal");
        rot.y = rotationFloat * rotationSpeed;
        transform.Rotate(rot);
        lockPinRotation = transform.eulerAngles;
        float value = Random.Range(2.5f, 357.5f);
        if (lockPinRotation.x > value - 2.5f && lockPinRotation.x < value + 2.5f)
        {
            topPin = true;
        }
        if(topPin == true)
        {
            movementFloat = Input.GetAxis("X");
            rot.y = movementFloat * rotationSpeed;

        }
        
    }
       
}       
