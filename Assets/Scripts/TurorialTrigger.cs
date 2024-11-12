
using KinematicCharacterController;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public DialogueText dialogueText;
    public GeckoTalking geckoTalking;
    private Collider collider;
    private Collider playerCollider;
    public Dialogue tutorialDialogue;
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

