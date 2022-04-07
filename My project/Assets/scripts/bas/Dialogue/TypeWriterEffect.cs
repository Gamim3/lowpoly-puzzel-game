using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public float typewriterSpeed = 50f;//is de snelheid met waarmee de letters op het scherm komen


    public Coroutine Run(string textToType, TMP_Text textLabel)//coroutine kan stoppen en doorgaan waar het gestopt is.
    {
        return StartCoroutine(routine: TypeText(textToType, textLabel));//start de coroutine typetext
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLabel)//een IEnumerator is een soort update
    {


        float t = 0;//de tijd die voorbij is gegaan sinds dat hij is gaan starten met typen
        int charIndex = 0;//is voor het ondthouden van de floorvalue van t

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * typewriterSpeed;// t word groter over tijd
            charIndex = Mathf.FloorToInt(t);//onthoud het laagste volledige cijfer van t (2.39 = 2, 9,93 = 9)
            charIndex = Mathf.Clamp(value: charIndex, min: 0, max: textToType.Length);//zorgt ervoor dat charIndex nooit grooter is dan de text die moet worden getypt.

            textLabel.text = textToType.Substring(startIndex: 0, length: charIndex);//typt de text


            yield return null;//stopt de coroutine en gaat verder op de volgende frame
        }

        textLabel.text = textToType;//checkt of de text die die wil typen gelijk is aan de text die is getypt
    }
}
