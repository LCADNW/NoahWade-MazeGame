using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public bool isFading = false;
    public Image panel;
    public float incrementDelay = 0.03f;
    public void FadeToBlack()
    {
        StartCoroutine(C_FadeToBlack());
    }

    public void FadeToVisible()
    {
        StartCoroutine (C_FadeToVisible());
    }


    IEnumerator C_FadeToBlack()
    {
        isFading = true;
        Color fade = Color.black;
        fade.a = 0;
        float increment = 0;
        while (increment < 0.95f)
        {
            increment += 0.02f;
            yield return new WaitForSeconds(incrementDelay);
            fade.a = increment;
            panel.color = fade;
        }
        fade.a = 1;
        panel.color = fade;
        isFading = false;
    }

    IEnumerator C_FadeToVisible()
    {
        isFading = true;
        Color fade = Color.black;
        fade.a = 1;
        float increment = 1;
        while (increment > 0.05f)
        {
            increment -= 0.02f;
            yield return new WaitForSeconds(incrementDelay);
            fade.a = increment;
            panel.color = fade;
        }
        fade.a = 0;
        panel.color = fade;
        isFading = false;

    }
}
