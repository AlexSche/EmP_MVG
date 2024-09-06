
using KinematicCharacterController;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public DialogueText dialogueText;
    public GeckoTalking geckoTalking;
    private Collider collider;
    private Collider playerCollider;
    public string[] tutorialDialogue = new string[] {
        "Ahhhhhh endlich ist jemand hier!!! Ich brauche deine Hilfe.",
        "Bevor du mir helfen kannst, versuch dich erst einmal zu orientieren.",
        "Das Ziel ist es den Ausgang aus den verschiedenen Räumen zu finden.",
        "Um den Ausgang zu erreichen kannst du dich wie ich an Wänden und Decken bewegen, wenn du durch verschiedene Durchgänge gehst.",
        "Probier es doch einfach mal aus und geh durch den Durchgang."
        };
    private bool tutorialStarted = false;
    void Awake()
    {
        collider = GetComponent<Collider>();
    }

    void Start()
    {
        var _playerController = FindFirstObjectByType<PlayerController>(FindObjectsInactive.Include);
        var _player = _playerController.GetComponent<KinematicCharacterMotor>();
        playerCollider = _playerController.GetComponent<Collider>();
    }
    void FixedUpdate()
    {
        if (collider.bounds.Intersects(playerCollider.bounds))
        {
            if (!tutorialStarted)
            {
                dialogueText.startDialogue(tutorialDialogue, geckoTalking);
                tutorialStarted = true;
            }
        }
    }
}

