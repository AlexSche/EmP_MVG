using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    public string sceneName;
    public GameObject loadingScreen;    // The loading screen object (a Canvas with UI)
    public Slider progressBar;          // Reference to the progress bar (optional)
    public Text loadingText;            // Reference to the loading text (optional)

    void Start()
    {
        Debug.Log("hello");
        // Call this function to load a scene asynchronously
        void LoadScene(string sceneName)
        {
            Debug.Log("0");
            // Start the asynchronous loading process
            StartCoroutine(LoadSceneAsync(sceneName));
        }
        LoadScene(sceneName);

        // Coroutine to handle the asynchronous scene loading
        IEnumerator LoadSceneAsync(string sceneName)
        {
            Debug.Log("1");
            // Show the loading screen UI
            loadingScreen.SetActive(true);
            Debug.Log("2");
            // Start loading the scene asynchronously in the background
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
            operation.allowSceneActivation = false; // Prevent the scene from switching immediately when loading finishes

            // While the scene is still loading
            while (!operation.isDone)
            {
                // Calculate the progress (loading progresses from 0 to 1)
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                // Update the progress bar and loading text, if they exist
                if (progressBar != null)
                {
                    progressBar.value = progress;  // Update the progress bar
                }

                if (loadingText != null)
                {
                    loadingText.text = (progress * 100f).ToString("F0") + "%";  // Update the loading text (percentage)
                }

                // If loading is almost done, activate the new scene
                if (operation.progress >= 0.9f)
                {
                    // Once loading reaches 90%, switch the scene
                    operation.allowSceneActivation = true;
                }

                yield return null;  // Wait for the next frame before continuing the loop
            }
        }
    }
}
