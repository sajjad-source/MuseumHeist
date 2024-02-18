using System.Collections;
using UnityEngine;

public class SimonSaysGame : MonoBehaviour
{
    public static SimonSaysGame Instance { get; private set; }

    public AudioSource audioSource;
    public AudioClip[] buttonBeeps;
    public AudioClip errorBeep;
    public AudioClip alarmSound; // Assign an alarm sound in the Inspector
    public VRButton[] buttons;
    public GameObject laserParent; // Assign the parent GameObject of the lasers in the Inspector
    private int[] sequence;
    private int sequenceLength = 3;
    private int currentStep = 0;
    private bool canInteract = false;
    private bool gameActive = false; // To control if the game is active

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Call this method from a proximity trigger or another script
    public void ActivateGame()
    {
        if (!gameActive)
        {
            gameActive = true;
            StartNewGame();
        }
    }

    void StartNewGame()
    {
        currentStep = 0;
        if (sequenceLength < 5) // If the sequence length is less than 5, increase it
        {
            sequenceLength++;
        }
        else
        {
            laserParent.SetActive(false); // Disable lasers and stop the game
            gameActive = false;
            return;
        }

        GenerateSequence();
        StartCoroutine(PlaySequence());
    }

    void GenerateSequence()
    {
        sequence = new int[sequenceLength];
        for (int i = 0; i < sequenceLength; i++)
        {
            sequence[i] = Random.Range(0, buttonBeeps.Length);
        }
    }


    IEnumerator PlaySequence()
    {
        canInteract = false;

        yield return new WaitForSeconds(1f);            // Wait before starting the sequence
        for (int i = 0; i < sequence.Length; i++)
        {
            buttons[sequence[i]].SetHighlightAppearance();
            audioSource.PlayOneShot(buttonBeeps[sequence[i]]);
            yield return new WaitForSeconds(1f);        // Wait between beeps
            buttons[sequence[i]].SetDefaultAppearance();
            yield return new WaitForSeconds(0.5f);      // Wait time after showing each button
        }

        canInteract = true;
    }

    public void ButtonPressed(int buttonIndex)
    {
        if (!canInteract || !gameActive)
            return;

        if (buttonIndex >= 0 && buttonIndex < buttonBeeps.Length)
        {
            if (sequence[currentStep] == buttonIndex)
            {
                audioSource.PlayOneShot(buttonBeeps[buttonIndex]);
                currentStep++;
                if (currentStep >= sequence.Length)
                {
                    Debug.Log("Sequence completed successfully!");
                    StartNewGame();
                }
            }
            else
            {
                audioSource.PlayOneShot(errorBeep);
                Debug.Log("Error: Sequence incorrect!");
                if (alarmSound != null)
                {
                    audioSource.PlayOneShot(alarmSound); // Play the alarm sound
                }
                gameActive = false; // Stop the game after an error
            }
        }
        else
        {
            Debug.LogError("ButtonPressed with invalid index: " + buttonIndex);
        }
    }
}
