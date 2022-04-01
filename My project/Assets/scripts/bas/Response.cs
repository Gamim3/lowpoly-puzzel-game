using UnityEngine;

[System.Serializable]
public class Response
{
    public string responseText;
    public DialogueObject dialogueObject;

    public string ResponseText => responseText;

    public DialogueObject DialogueObject => dialogueObject;


}
