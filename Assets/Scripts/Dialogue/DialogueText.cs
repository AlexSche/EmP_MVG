using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueText : MonoBehaviour
{
    private TextWriter textWriter;
    private TMP_Text tmpObject;
    private string[] dialogue;
    private int dialoguePosition;
    private AudioSource audioSourceNotification;
    private AudioSource audioSourceVoice;

    public InputActionReference continueDialogueAction;
    private void Awake()
    {
        continueDialogueAction.action.Enable();
        continueDialogueAction.action.performed += continueDialogue;

        tmpObject = GetComponentInChildren<TMP_Text>();
        textWriter = GetComponent<TextWriter>();
        audioSourceNotification = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        continueDialogueAction.action.Disable();
        continueDialogueAction.action.performed -= continueDialogue;
    }

    public void startDialogue(string[] dialogue)
    {
        this.dialogue = dialogue;
        StartCoroutine(dialogueIsStarting());
    }

    void continueDialogue(InputAction.CallbackContext context)
    {
        // set text on panel to the next dialogue option
        if (dialoguePosition < dialogue.Length - 1)
        {
            dialoguePosition++;
            tmpObject.text = dialogue[dialoguePosition];
        }
        else
        {
            stopDialogue();
        }
    }

    void stopDialogue()
    {
        gameObject.SetActive(false);
        audioSourceNotification.Play();
    }

    IEnumerator dialogueIsStarting()
    {
        tmpObject.text = "Sprache wird übersetzt...";
        audioSourceNotification.Play();
        yield return new WaitForSeconds(2);
        gameObject.SetActive(true);
        if (dialogue != null && dialogue.Length > 0)
        {
            dialoguePosition = 0;
            textWriter.addWriter(tmpObject, dialogue[dialoguePosition]);
        }
    }
}
