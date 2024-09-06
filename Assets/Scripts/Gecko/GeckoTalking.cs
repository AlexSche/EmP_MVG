using System.Collections;
using UnityEngine;

public class GeckoTalking : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    private AudioSource audioSourceVoice;
    private bool isSpeaking = false;
    private bool shouldStopTalking = false;
    public DialogueText dialogueText;
    private string[] testDialogue = new string[] { "Hallo, hier in der Ecke!", "Cool, dass du hier bist. Ich brauche nämlich Hilfe.", "Kannst du mich von der Decke holen?" };

    void Start()
    {
        dialogueText.startDialogue(testDialogue, this);
        audioSourceVoice = GetComponent<AudioSource>();
    }

    public void speakGibberishOnLoop()
    {
        shouldStopTalking = false;
        isSpeaking = true;
        StartCoroutine(speakGibberish(audioClips));
    }

    IEnumerator speakGibberish(AudioClip[] clips)
    {
        while (isSpeaking)
        {
            audioSourceVoice.Stop();
            int randomInt = Random.Range(0, clips.Length - 1);
            audioSourceVoice.clip = clips[randomInt];
            audioSourceVoice.Play();
            while (audioSourceVoice.isPlaying)
            {
                yield return null;
                if (shouldStopTalking)
                {
                    break;
                }
            }
        }
    }

    public void stopTalking()
    {
        isSpeaking = false;
        shouldStopTalking = true;
    }
}
