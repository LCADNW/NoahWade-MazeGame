using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakingTextGenerator : MonoBehaviour
{
    public GameObject textPrefab;
    public Transform generationParent;

    public void Generate(string words)
    {
        GameObject newWords = Instantiate(original: textPrefab, generationParent, false);
        newWords.transform.SetParent(null);
        newWords.transform.rotation = Quaternion.identity;
        newWords.GetComponent<SpeakingText>().SpeakWords(words);
    }
}
