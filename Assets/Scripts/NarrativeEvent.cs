using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class NarrativeEvent : MonoBehaviour
{
    public string eventName;
    public bool onStart = false;
    [ShowIf("onStart")] public UnityEvent StartEvents;
    public UnityEvent Occurance;

    // Start is called before the first frame update
    void Start()
    {
        if (!onStart) return;
        StartEvents?.Invoke();
    }

    public void Occur()
    {
        Occurance?.Invoke();
    }

    public void DelayDoOccurance(float delay)
    {
        StartCoroutine(C_DelayDoOccurance(delay));
    }

    IEnumerator C_DelayDoOccurance(float delay)
    {
        yield return new WaitForSeconds(delay);
        Occur();
    }
}
