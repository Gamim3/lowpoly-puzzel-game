using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementXY : MonoBehaviour
{
    public float axisZ;
    public float axisX;

    public Vector3 playerPos;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        axisX = Input.GetAxis("Horizontal");
        axisZ = Input.GetAxis("Vertical");

        playerPos.x = axisX;
        playerPos.z = axisZ;

        


        transform.Translate(playerPos * moveSpeed * Time.deltaTime, Space.Self);
    }
}
