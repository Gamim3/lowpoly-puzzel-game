using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// interactscript zorcht ervoor dat je in het ui kan komen en dat de playermovement word gedisabled;

public class InteractScript : MonoBehaviour
{
    public DialogeuUI dialogeuUI;

    public DialogeuUI DialogeuUI => dialogeuUI;//pakt de dialogueUI, zorgt ervoor dat je de dialogue niet kan overwrighten

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
                if (Interactible != null)// != is IS NOT, 
                {
                    Interactible.Interact(interactScript: this);//this is dit 
                    player.GetComponent<PlayerMovement>().inMenu = true;
                    playerCamera.GetComponent<MouseLook>().inMenu = true;

                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }
}
