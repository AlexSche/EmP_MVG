using System;
using TMPro;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    private TMP_Text tmpObject;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter = 0.1f;
    private float timer;
    private Action onComplete;

    void Update()
    {
        if (tmpObject != null) {
            timer -= Time.deltaTime;
            if (timer <= 0f) {
                // Display next character
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color";
                tmpObject.text = text;

                if (characterIndex >= textToWrite.Length) {
                    tmpObject = null;
                    if (onComplete != null) onComplete();
                    return;
                }
            }
        }
    }

    public void addWriter(TMP_Text tmpObject, string textToWrite, Action onComplete) {
        this.tmpObject = tmpObject;
        this.textToWrite = textToWrite;
        this.onComplete = onComplete;
        characterIndex = 0;
    }
}
