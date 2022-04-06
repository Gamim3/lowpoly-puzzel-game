using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public Animator door;
    public string close;

    public GameObject liftObject;

    public string sceneName;

    public bool canChangeScene;

    public bool inTrigger;
    public float waitUntilChange;

    public bool waiting;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }
    public void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
    void Update()
    {
        if (inTrigger == true)
        {
            if(canChangeScene == true && Input.GetButtonDown("Use"))
            {
                door.Play(close);
                liftObject.SetActive(true);
                waiting = true;
            }
            if(waiting == true)
            {
                waitUntilChange -= 1f * Time.deltaTime;
            }
        }
        if (waitUntilChange <= 0)
        {
            waiting = false;
            SceneManager.LoadScene(sceneName);
        }
    }
}
