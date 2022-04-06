using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    public GameObject newDialogue;
    public GameObject oldDialogue;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "cube")
        {
            newDialogue.SetActive(true);
            oldDialogue.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "cube")
        {
            newDialogue.SetActive(false);
            oldDialogue.SetActive(true);
        }
    }
}
