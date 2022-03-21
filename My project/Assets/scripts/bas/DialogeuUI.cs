using UnityEngine;
using TMPro;

public class DialogeuUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textlabel;

    private void Start()
    {
        GetComponent<TypeWriterEffect>().Run(textToType: "this is a bit of text.\n Hello!", textlabel);
    }
}
