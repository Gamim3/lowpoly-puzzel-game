using System.Collections;
using UnityEngine;
using TMPro;

public class DialogeuUI : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text textLabel;

    public bool IsOpen { get; private set; }

    private TypeWriterEffect typewritereffect;
    private ResponseHandler responseHandler;

    public GameObject player;
    public GameObject playerCamera;

    private void Start()
    {
        typewritereffect = GetComponent<TypeWriterEffect>();
        responseHandler = GetComponent<ResponseHandler>();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        IsOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(routine: StepThroughDialogue(dialogueObject));
        
    }

    public void AddResponseEvents(ResponseEvent[] responseEvents)
    {
        responseHandler.AddResponseEvents(responseEvents);
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for(int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewritereffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.hasResponses) break;
            yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));

        }

        if (dialogueObject.hasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    private void CloseDialogueBox()
    {
        IsOpen = false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;

        player.GetComponent<PlayerMovement>().inMenu = false;
        playerCamera.GetComponent<MouseLook>().inMenu = false;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
