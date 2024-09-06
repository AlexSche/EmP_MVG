using TMPro;
using UnityEngine;

public class DialogueText: MonoBehaviour
{
    private GameObject panel;
    private TMP_Text tmpObject;
    private string[] dialogue;
    private int dialoguePosition;

    void Start() {
        tmpObject = GetComponent<TMP_Text>();
        panel = GetComponentInParent<GameObject>();
    }

    void startDialogue(string[] dialogue) {
        panel.SetActive(true);
        // play audio cue
        if (dialogue != null && dialogue.Length > 0) {
            dialoguePosition = 0;
            tmpObject.text = dialogue[dialoguePosition];
        }
    }

    void continueDialogue() {
        // set text on panel to the next dialogue option
        if (dialoguePosition <= dialogue.Length) {
            dialoguePosition++;
            tmpObject.text = dialogue[dialoguePosition];
        } else {
            stopDialogue();
        }
    }

    void stopDialogue() {
        panel.SetActive(false);
        // play audio cue
    }
}
