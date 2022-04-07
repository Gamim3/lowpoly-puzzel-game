using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockScript : MonoBehaviour
{
    public bool fourthPin;
    public bool lockOpener;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fourthPin = true)
        {
            lockOpener = true;
        }
    }
}
