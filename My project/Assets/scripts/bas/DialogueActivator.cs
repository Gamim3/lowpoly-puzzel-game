using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractible
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out InteractScript interactScript))
        {
            interactScript.Interactible = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out InteractScript interactScript))
        {
            if (interactScript.Interactible is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                interactScript.Interactible = null;
            }
        }
    }

    public void Interact(InteractScript interactScript)
    {
        interactScript.DialogeuUI.ShowDialogue(dialogueObject);
    }
}
