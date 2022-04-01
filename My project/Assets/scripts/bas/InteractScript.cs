using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    public DialogeuUI dialogeuUI;

    public DialogeuUI DialogeuUI => dialogeuUI;

    public IInteractible Interactible { get; set; }

    public GameObject player;
    public GameObject playerCamera;

    public bool inMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inMenu == true) return;
        if (Input.GetButtonDown("Use"))
        {
            if (Interactible != null)
            {
                Interactible.Interact(interactScript: this);
                player.GetComponent<PlayerMovement>().inMenu = true;
                playerCamera.GetComponent<MouseLook>().inMenu = true;

                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}
