using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public AudioSource alarmSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerAlarm();
        }
    }

    private void TriggerAlarm()
    {
        if (!alarmSound.isPlaying)
        {
            alarmSound.Play();
        }
    }
}
