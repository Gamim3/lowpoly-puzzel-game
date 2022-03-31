using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractible
{
    [SerializeField] private DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }


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
        if (TryGetComponent(out DialogueResponseEvents responseEvents) && responseEvents.DialogueObject == this)
        {
            interactScript.DialogeuUI.AddResponseEvents(responseEvents.Events);
        }
        interactScript.DialogeuUI.ShowDialogue(dialogueObject);
    }
}
