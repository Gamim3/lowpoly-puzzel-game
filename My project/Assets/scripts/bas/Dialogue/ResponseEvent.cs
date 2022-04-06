using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class ResponseEvent
{
    [HideInInspector] public string name;
    public UnityEvent onPickedResponse;

    public UnityEvent OnPickedResponse => onPickedResponse;
}
