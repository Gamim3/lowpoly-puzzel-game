using System.Collections;
using UnityEngine;
using TMPro;
// tutorial van https://www.youtube.com/c/SemagGames

// DialogueUI word gebruikt om de text en responses te laten zien in het UI
public class DialogeuUI : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text textLabel;

    public bool isOpen { get; private set; }//zorgt ervoor dat alleen dialogueUI hem true or false kan zetten maar andere scripts kunnen het wel zien

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
        isOpen = true;
        dialogueBox.SetActive(true);//zet de dialogue box aan
        StartCoroutine(routine: StepThroughDialogue(dialogueObject));
        
    }


    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        for(int i = 0; i < dialogueObject.Dialogue.Length; i++)//wacht tot dat de speler op fire 1 klikt als er geen response is.(i++ = i word groter elke keer dat deze lijn komt
        {
            string dialogue = dialogueObject.Dialogue[i];//string dialogue word gelijk aan de dialogue text in dialogue object met i als index
            yield return typewritereffect.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.hasResponses) break;//als hij responses heeft stopt hij hier
            yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));//stopt de coroutine todat je klikt

        }

        if (dialogueObject.hasResponses)//als de dialogue een response heeft laat hij de responses als hij geen responses heeft CloseDialogueBox
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
        isOpen = false;
        dialogueBox.SetActive(false);//zet de dialogue box uit
        textLabel.text = string.Empty;//zet de text naar niks

        player.GetComponent<PlayerMovement>().inMenu = false;
        playerCamera.GetComponent<MouseLook>().inMenu = false;

        Cursor.lockState = CursorLockMode.Locked;
    }
}
