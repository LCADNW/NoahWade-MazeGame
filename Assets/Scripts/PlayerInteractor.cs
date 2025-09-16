using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractor : MonoBehaviour
{
    public bool interactionEnabled;
    public bool canInteract;
    Action interactCallback;

    private void Update()
    {
        if (!interactionEnabled) return;
        if (!canInteract) return;

        if (Input.GetKeyDown(KeyCode.E))
            Callback();
    }

    void Callback()
    {
        print(message: $"Callback executed {interactCallback.ToString()} ");
        interactCallback?.Invoke();

    }

    public void InRange(Action callback)
    {
        interactCallback = callback;
        print($"In range with {callback.ToString()}");
        canInteract = true;
    }

    public void OutOfRange()
    {
        interactCallback = null;
        canInteract = false;
    }

    public void ToggleInteraction(bool val)
    {
        interactionEnabled = val;
    }
}
