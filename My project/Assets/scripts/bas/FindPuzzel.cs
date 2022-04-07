using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPuzzel : MonoBehaviour
{
    public GameObject canTransition;

    public RaycastHit hit;

    public float raycastLenght;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            if(Physics.Raycast(transform.position, transform.forward, out hit, raycastLenght))
            {
                if(hit.transform.gameObject.tag == "LiftPas")
                {
                    canTransition.GetComponent<SceneTransition>().canChangeScene = true;
                    hit.transform.gameObject.SetActive(false);
                }
            }
        }
    }
}
