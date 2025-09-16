using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Events;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool canInteract = true;
    public bool automatic = false;
    public bool canInteractMoreThanOnce = false;
    bool interactedWith = false;
    public UnityEvent onInteract;
    public UnityEvent onCantInteract;
    public LayerMask player;

    private void Start()
    {
        onInteract.AddListener(InteractedWith);
    }


    public void Interact()
    {
        if (!canInteract)
        {
            onCantInteract?.Invoke();
            return;
        }
        onInteract?.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!canInteractMoreThanOnce && interactedWith) return;

        if ((player.value & (1 << other.gameObject.layer)) == 0) return;
        if (other.GetComponent<PlayerSingleton>())
        {
            if (!automatic)
                PlayerSingleton.Instance.GetComponent<PlayerInteractor>().InRange(Interact);
            else
                onInteract?.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if ((player.value & (1 << other.gameObject.layer)) == 0) return;
        if (other.GetComponent<PlayerSingleton>())
            PlayerSingleton.Instance.GetComponent<PlayerInteractor>().OutOfRange();
    }

    void InteractedWith()
    {
        interactedWith = true;
    }

    public void ToggleCanInteract(bool val)
    {
        canInteract = val;
    }
}
