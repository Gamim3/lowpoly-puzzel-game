using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourthPin : MonoBehaviour
{
    public bool activePin;
    public bool firstPin;
    public float rotationSpeed = 0.1f;
    public Vector3 rot;
    public float rotationFloat;
    public Vector3 lockPinRotation;
    public GameObject nextPin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (activePin)
        {
            rotationFloat = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up * rotationFloat * rotationSpeed);
            lockPinRotation = transform.eulerAngles;
            float value = Random.Range(2.5f, 357.5f);

            if (lockPinRotation.z > value - 2.5f && lockPinRotation.z < value + 2.5f)
            {
                firstPin = true;
            }
            if (firstPin == true)
            {
                nextPin.GetComponent<PinScript>().activePin = true;
                activePin = false;
            }
        }

    }
}
