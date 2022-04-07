using UnityEngine;

[System.Serializable]
public class Response
{
    public string responseText;//text die in de response button komt
    public DialogueObject dialogueObject;//volgende dialogue object dat komt wanneer je op deze response klikt

    public string ResponseText => responseText;//pakt de response text, zorgt ervoor dat je de dialogue niet kan overwrighten

    public DialogueObject DialogueObject => dialogueObject;//pakt de , zorgt ervoor dat je de dialogue niet kan overwrighten

    public bool hasEvent;

    public Vector3 activatorLoc;

    public GameObject reaction;
}
