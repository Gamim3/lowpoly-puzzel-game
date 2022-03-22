using System.Collections;
using UnityEngine;
using TMPro;

public class DialogeuUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;

    private TypeWriterEffect typewritereffect;

    private void Start()
    {
        typewritereffect = GetComponent<TypeWriterEffect>();
        ShowDialogue(testDialogue);
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        StartCoroutine(routine: StepThroughDialogue(dialogueObject));
        
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {
        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewritereffect.Run(dialogue, textLabel);
            yield return new WaitUntil(() => Input.GetButtonDown("Fire1"));
        }

        CloseDialogueBox();
    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }
}
