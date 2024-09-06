using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueText : MonoBehaviour
{
    private TMP_Text tmpObject;
    private string[] dialogue;
    private int dialoguePosition;

    public InputActionReference continueDialogueAction;
    private void Awake() {
        continueDialogueAction.action.Enable();
        continueDialogueAction.action.performed += continueDialogue;
    }

    private void OnDestroy() {
        continueDialogueAction.action.Disable();
        continueDialogueAction.action.performed -= continueDialogue;
    }

    void Start()
    {   
        tmpObject = GetComponentInChildren<TMP_Text>();
    }

    public void startDialogue(string[] dialogue)
    {
        this.dialogue = dialogue;
        this.gameObject.SetActive(true);
        // TODO: play audio cue
        if (dialogue != null && dialogue.Length > 0)
        {
            dialoguePosition = 0;
            tmpObject.text = dialogue[dialoguePosition];
        }
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
        this.gameObject.SetActive(false);
        // TODO: play audio cue
    }
}
