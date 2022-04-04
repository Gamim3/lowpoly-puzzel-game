using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEventHelper : MonoBehaviour
{
    public GameObject cube;
    public bool aan;

    public RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            aan = true;
            cube.GetComponent<aanUit>().Uit();
        }
    }
}
