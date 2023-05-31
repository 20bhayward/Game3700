using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
    public Text sentenceText;
    public string sentence = "One Two Many";
    public float typingSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(TypeSentence());
    }

    private System.Collections.IEnumerator TypeSentence()
    {
        sentenceText.text = "";
        foreach (char letter in sentence)
        {
            sentenceText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}