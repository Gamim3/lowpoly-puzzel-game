using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoor : MonoBehaviour
{
    public Animator door;
    public string open;
    public string close;

    public bool inTrigger;

    public bool isOpen;

    public GameObject lift;
    public GameObject liftObject;

    public bool canChangeScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    // Update is called once per frame
    void Update()
    {
        canChangeScene = lift.GetComponent<SceneTransition>().canChangeScene;
        if(inTrigger == true)
        {
            if (Input.GetButtonDown("Use") && canChangeScene == true)
            {
                if (isOpen == false)
                {
                    door.Play(open);
                    isOpen = true;
                    liftObject.SetActive(false);
                }
            }
        }
    }
}
