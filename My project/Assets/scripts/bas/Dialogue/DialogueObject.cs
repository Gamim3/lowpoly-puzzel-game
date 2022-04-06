using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [TextArea] public string[] dialogue;
    public Response[] responses;

    public string[] Dialogue => dialogue;

    public bool hasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}
