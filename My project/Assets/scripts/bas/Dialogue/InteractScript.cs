using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// interactscript zorcht ervoor dat je in het ui kan komen en dat de playermovement word gedisabled;

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
        if (inMenu == false)// kijkt of je al in een menu zit.
        {
            if (Input.GetButtonDown("Use"))//kijkt of je de E knop inklikt
            {
                if (Interactible != null)// != is ISNOT, 
                {
                    Interactible.Interact(interactScript: this);
                    player.GetComponent<PlayerMovement>().inMenu = true;
                    playerCamera.GetComponent<MouseLook>().inMenu = true;

                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
}
