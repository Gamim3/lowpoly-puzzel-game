using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIn : MonoBehaviour
{
    public Animator door;
    public string close;
    public string open;

    public GameObject liftObject;

    public bool isFirst;

    public float waitUntilChange;
    public bool startTimer;
    public bool canChange;

    // Update is called once per frame
    private void Start()
    {
        door.Play(open);
        liftObject.SetActive(false);
    }

    private void Update()
    {
        if (startTimer == true)
        {
            waitUntilChange -= 1f * Time.deltaTime;
        }
        if (waitUntilChange <= 0f && startTimer == true)
        {
            canChange = true;
        }
        if (canChange == true)
        {
            door.Play(close);
            isFirst = false;
            liftObject.SetActive(true);
            startTimer = false;
            canChange = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFirst == true && other.tag == "Player")
        {
            startTimer = true;
        }
    }
}
