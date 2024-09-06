using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeckoTalking : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    private AudioSource audioSourceVoice;
    private bool isSpeaking = false;
    private bool shouldStopTalking = false;

    public DialogueText dialogueText;
    private string[] testDialogue = new string[] {"Hallo, hier in der Ecke!", "Cool, dass du hier bist. Ich brauche nämlich Hilfe.", "Test, Test, Test"};

    void Start() {
        dialogueText.startDialogue(testDialogue);
        //audioSource = GetComponent<AudioSource>();
        //speakGibberishOnLoop(audioClips);
    }

    public void speakGibberishOnLoop(AudioClip[] clips) {
        StartCoroutine(speakGibberish(clips));
    }

    IEnumerator speakGibberish(AudioClip[] clips) {
        isSpeaking = true;
        for(int i = 0; i <= clips.Length-1; i++) {
            audioSourceVoice.Stop();
            audioSourceVoice.clip = clips[i];
            audioSourceVoice.Play();
            while (audioSourceVoice.isPlaying) {
                yield return null;
            }
        }
        yield return new WaitForSeconds(2);
        /*
        while (isSpeaking) {
            audioSource.Stop();
            int chosenClip = Random.Range(0, clips.Length - 1);
            audioSource.clip = clips[chosenClip];
            while (audioSource.isPlaying) {
                yield return null;
                if (shouldStopTalking) {
                    isSpeaking = false;
                    break;
                }
            }
        }
        */
    }

    public void stopTalking() {
        shouldStopTalking = true;
    }
}
