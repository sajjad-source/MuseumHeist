using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WeightSensitivePedestal : MonoBehaviour
{
    public GameObject artifact;
    public GameObject replica;
    public AudioClip successClip;
    public AudioClip failureClip;
    private AudioSource audioSource;
    private bool isArtifactPresent = true;
    private float timer = 0f;
    private bool isTimerRunning = false;
    public float timeToReplace = 5f; // Time in seconds to replace the artifact with the replica

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime;
            if (timer > timeToReplace)
            {
                TriggerFailure();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == artifact)
        {
            Debug.Log("Trigger Exited: " + other.gameObject.name);

            isArtifactPresent = false;
            isTimerRunning = true;
            timer = 0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == replica && !isArtifactPresent)
        {
            Debug.Log("Trigger Entered: " + other.gameObject.name);

            isArtifactPresent = true;
            isTimerRunning = false;
            TriggerSuccess();
        }
    }

    private void TriggerSuccess()
    {
        Debug.Log("Success triggered");
        audioSource.PlayOneShot(successClip);
        StartCoroutine(SwitchToARSceneAfterDelay(2f));
    }

    private void TriggerFailure()
    {
        if (!isArtifactPresent)
        {
            Debug.Log("Failure triggered");
            audioSource.PlayOneShot(failureClip);
            isTimerRunning = false;
            
        }
    }

    private IEnumerator SwitchToARSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("ARFinal");
    }
}
