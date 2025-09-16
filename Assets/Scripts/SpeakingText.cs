using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeakingText : MonoBehaviour
{
    TMP_Text text;

    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();
    }
    public void SpeakWords(string words)
    {
        text.text = words;
        StartCoroutine(CreateElipsiesEffect());
    }

    IEnumerator CreateElipsiesEffect()
    {
        for(int i = 5; i > 0; i--)
        {
            yield return new WaitForSeconds(0.5f);
            text.text = text.text + " .";
        }
        StartCoroutine(FadeTextThenDelete());
    }

    IEnumerator FadeTextThenDelete()
    {
        float iteration = 1;
        Color color = Color.white;
        while(iteration > 0.05f)
        {
            color.a = iteration;
            text.color = color;
            iteration -= 0.012f;
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(gameObject);
    }


}
