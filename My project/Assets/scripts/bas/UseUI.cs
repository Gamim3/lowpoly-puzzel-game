using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseUI : MonoBehaviour
{
    public GameObject useUI;

    public bool showUI;

    private void OnTriggerEnter(Collider other)
    {
        showUI = true;
    }
    private void OnTriggerExit(Collider other)
    {
        showUI = false;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            showUI = false;
        }
        if(showUI == true)
        {
            ActivateUI();
        }
        else
        {
            DeActivateUI();
        }
    }

    public void ActivateUI()
    {
        useUI.SetActive(true);
    }

    public void DeActivateUI()
    {
        useUI.SetActive(false);
    }
}
