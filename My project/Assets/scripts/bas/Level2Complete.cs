using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Complete : MonoBehaviour
{
    public GameObject worldEventHelper;
    public GameObject lift;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(worldEventHelper.GetComponent<WorldEventHelper>().aan == true)
        {
            lift.GetComponent<SceneTransition>().canChangeScene = true;
        }
    }
}
