using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    public bool firstPin;
    public float rotationSpeed = 0.1f;
    public Vector3 rot;
    public float rotationFloat;
    public float movementFloat;
    public Vector3 lockPinRotation;
    public float maxAngle = 0f;
    public GameObject nextPin;
    public bool PinRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationFloat = Input.GetAxis("Horizontal");
        rot.z = rotationFloat * rotationSpeed;
        transform.Rotate(rot);
        lockPinRotation = transform.eulerAngles;
        float value = Random.Range(2.5f, 357.5f);
        if (lockPinRotation.z > value - 2.5f && lockPinRotation.z < value + 2.5f)
        {
            firstPin = true;
        }
        if (firstPin == true)
        {
          nextPin.GetComponent<SecondPinTest>();
        }
    }
}
