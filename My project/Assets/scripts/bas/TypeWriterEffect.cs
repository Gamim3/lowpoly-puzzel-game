using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public void Run(string textToType, TMP_Text textlabel)
    {
        StartCoroutine(routine: TypeText(textToType, textlabel));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textlabel)
    {
        float t = 0;
        int charIndex = 0;

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(value: charIndex, min: 0, max: textToType.Length);

            textlabel.text = textToType.Substring(startIndex: 0, length: charIndex);
        }

        textlabel.text = textToType;
    }
}
