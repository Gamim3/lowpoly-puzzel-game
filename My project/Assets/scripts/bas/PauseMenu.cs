using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public GameObject player;
    public GameObject playerCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (player.GetComponent<PlayerMovement>().inMenu != true)
            {
                Cursor.lockState = CursorLockMode.None;
                player.GetComponent<PlayerMovement>().inMenu = true;
                playerCam.GetComponent<MouseLook>().inMenu = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                player.GetComponent<PlayerMovement>().inMenu = false;
                playerCam.GetComponent<MouseLook>().inMenu = false;
                pauseMenu.SetActive(false);
            }
        }
    }
    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        player.GetComponent<PlayerMovement>().inMenu = false;
        playerCam.GetComponent<MouseLook>().inMenu = false;
    }
}
