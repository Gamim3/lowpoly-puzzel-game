using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{

    public GameObject grab;

    public GameObject rubix;

    public Vector3 grabLocation;

    public RaycastHit hit;

    public float raycastLengte;

    public bool grabbing;
    public bool isGrabbing;

    public GameObject useUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grabLocation = grab.transform.position;
        if (Physics.Raycast(transform.position,transform.forward, out hit, raycastLengte) && isGrabbing == false)
        {
            if (hit.transform.gameObject.tag == "cube")
            {
                useUI.SetActive(true);
            }
        }
        else
        {
            if(useUI.active == false)
            {
                useUI.SetActive(false);
            }
        }

        if (Input.GetButtonDown("Use"))
        {
            if (grabbing == true)
            {
                isGrabbing = false;
                grabbing = false;
                return;
            }
            if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLengte) && isGrabbing == false)
            {
                if (hit.transform.gameObject.tag == "cube")
                {
                    grabbing = true;

                    isGrabbing = true;
                }
            }
        }

        if (grabbing == true)
        {
            rubix.transform.position = grabLocation;
            rubix.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
        }
        
    }
}
