using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{

   public GameObject teleportLocation;
   public Image panel;
    bool isAlreadyTeleporting = false;


   public void Warp()
    {
       if (isAlreadyTeleporting) return;
        StartCoroutine(WarpFade());
            



    }

   public IEnumerator WarpFade()
    {
        isAlreadyTeleporting=true;
        Color fade = Color.black;
        fade.a = 0;
        float increment = 0;
        while (increment < 0.9f)
        {
            increment += 0.05f;
            yield return new WaitForSeconds(0.05f);
            fade.a = increment;
            panel.color = fade;
        }
        
        PlayerSingleton.Instance.GetComponent<Transform>().position = teleportLocation.transform.position;

        while (increment > 0.1f)
        {
            increment -= 0.05f;
            yield return new WaitForSeconds(0.05f);
            fade.a = increment;
            panel.color = fade;


        }

    }
}
