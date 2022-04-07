using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fout : MonoBehaviour
{
    public string scene;

    public GameObject hit;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<WorldEventHelper>().aan == true)
        {
            SceneManager.LoadScene(scene);
            hit = GetComponent<WorldEventHelper>().hit.transform.gameObject;
            Destroy(hit);
        }
    }
}
