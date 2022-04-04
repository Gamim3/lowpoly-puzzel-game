using UnityEngine;

[System.Serializable]
public class Response
{
    public string responseText;
    public DialogueObject dialogueObject;

    public string ResponseText => responseText;

    public DialogueObject DialogueObject => dialogueObject;

    public bool hasEvent;

    public Vector3 activatorLoc;

    public GameObject reaction;
}
