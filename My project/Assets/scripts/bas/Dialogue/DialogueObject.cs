using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]//maakt een assetmenu aan voor unity
public class DialogueObject : ScriptableObject
{
    [TextArea] public string[] dialogue;//maakt een textgebied in scripteble object aan waar je dialogue in kan zetten
    public Response[] responses;//maakt een lijst van responses

    public string[] Dialogue => dialogue;//pakt de text die in textarea, zorgt ervoor dat je de dialogue niet kan overwrighten

    public bool hasResponses => Responses != null && Responses.Length > 0;//kijkt of er responses zijn en of ze een lengte hebben groter dan 0.

    public Response[] Responses => responses;//pakt de responses, zorgt ervoor dat je de dialogue niet kan overwrighten
}
