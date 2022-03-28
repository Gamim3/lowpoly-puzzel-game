using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour
{
    [SerializeField] private DialogeuUI dialogeuUI;

    public DialogeuUI DialogeuUI => dialogeuUI;

    public IInteractible Interactible { get; set; }  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Use"))
        {
            if (Interactible != null)
            {
                Interactible.Interact(interactScript: this);
            }
        }
    }
}
