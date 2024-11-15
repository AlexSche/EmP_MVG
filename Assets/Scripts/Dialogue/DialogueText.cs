using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueText : MonoBehaviour
{
    private TextWriter textWriter;
    private TMP_Text tmpObject;
    private Dialogue dialogue;
    private int dialoguePosition;
    private AudioSource audioSourceNotification;
    private AudioSource audioSourceVoice;
    private GeckoTalking gecko;
    public InputActionReference continueDialogueAction;
    private void Awake()
    {
        continueDialogueAction.action.Enable();
        continueDialogueAction.action.performed += continueDialogue;

        tmpObject = GetComponentInChildren<TMP_Text>();
        textWriter = GetComponent<TextWriter>();
        audioSourceNotification = GetComponent<AudioSource>();

        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        continueDialogueAction.action.Disable();
        continueDialogueAction.action.performed -= continueDialogue;
    }

    public void startDialogue(Dialogue dialogue, GeckoTalking geckoTalking)
    {
        this.dialogue = dialogue;
        this.gecko = geckoTalking;
        gameObject.SetActive(true);
        StartCoroutine(dialogueIsStarting());
    }

    void continueDialogue(InputAction.CallbackContext context)
    {
        // set text on panel to the next dialogue option
        if (dialoguePosition < dialogue.text.Length - 1)
        {
            dialoguePosition++;
            useTextwriter(tmpObject, dialogue.text[dialoguePosition]);
        }
        else
        {
           StartCoroutine(stopDialogue());
        }
    }

    IEnumerator stopDialogue()
    {
        audioSourceNotification.Play();
        yield return new WaitForSeconds(1);
        gecko.StopAllCoroutines();
        gameObject.SetActive(false);
    }

    IEnumerator dialogueIsStarting()
    {
        tmpObject.text = "Sprache wird übersetzt...";
        audioSourceNotification.Play();
        yield return new WaitForSeconds(2);
        if (dialogue != null && dialogue.text.Length > 0)
        {
            dialoguePosition = 0;
            useTextwriter(tmpObject, dialogue.text[dialoguePosition]);
        }
    }


    void useTextwriter(TMP_Text tmpObject, string textToWrite) {
        gecko.speakGibberishOnLoop();
        textWriter.addWriter(tmpObject, dialogue.text[dialoguePosition], gecko.stopTalking);
    }
}
