using UnityEngine;

//behandelt de vraag naar de dialogue ui interactie
// dit scipt stuurt de gewenste dialogue object door naar dialogue ui
public class DialogueActivator : MonoBehaviour, IInteractible
{
    public DialogueObject dialogueObject;

    public void UpdateDialogueObject(DialogueObject dialogueObject)
    {
        this.dialogueObject = dialogueObject;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out InteractScript interactScript))//als de player interact en hij heeft de interact script
        {
            interactScript.Interactible = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out InteractScript interactScript))//als de player interact en hij heeft de interact script
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
