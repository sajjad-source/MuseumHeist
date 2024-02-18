using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISequenceController : MonoBehaviour
{
    public GameObject[] uiImages; // Assign your UI Images in the inspector
    public float delayBeforeStart = 2f; // Seconds before the sequence starts
    public float delayBetweenImages = 5f; // Seconds between each UI Image
    public AudioSource duckAudioSource; // Assign an AudioSource component for playing the duck noise
    public AudioClip duckNoiseClip; // Assign the duck noise AudioClip
    public Animator duckAnimator; // Assign the Animator component of the duck character
    public string talkingAnimationName = "DuckTalking"; // The name of the talking animation in your Animator

    private IEnumerator Start()
    {
        // Wait before starting the sequence
        yield return new WaitForSeconds(delayBeforeStart);

        foreach (var uiImage in uiImages)
        {
            uiImage.SetActive(false); // Initially hide all images
        }

        foreach (var uiImage in uiImages)
        {
            // Show UI Image
            uiImage.SetActive(true);

            // Play duck noise and start talking animation
            duckAudioSource.clip = duckNoiseClip;
            duckAudioSource.Play();
            duckAnimator.SetBool(talkingAnimationName, true);

            // Wait for the specified delay
            yield return new WaitForSeconds(delayBetweenImages);

            // Hide UI Image and stop talking animation
            uiImage.SetActive(false);
            duckAnimator.SetBool(talkingAnimationName, false);

            // Optional: Add a short delay here if you want a pause before the duck returns to idle
            yield return new WaitForSeconds(0.5f);

            // Ensure the animation has time to transition back to idle
            if (duckAudioSource.isPlaying)
            {
                duckAudioSource.Stop();
            }
        }

        // Ensure duck returns to idle state at the end of the sequence
        duckAnimator.SetBool(talkingAnimationName, false);
    }
}
