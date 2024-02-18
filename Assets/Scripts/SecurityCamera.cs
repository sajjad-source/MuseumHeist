using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public float distractionSpeed = 1f;
    public float distractionDuration = 5f;
    private Transform distractionPoint;
    private Quaternion originalRotation;
    private float distractionTimer;
    private bool isDistracted = false;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        if (isDistracted)
        {
            if (distractionTimer > 0)
            {
                distractionTimer -= Time.deltaTime;
                if (distractionPoint != null)
                {
                    Vector3 direction = distractionPoint.position - transform.position;
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * distractionSpeed);
                }
            }
            else
            {
                // Return to original rotation
                transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * distractionSpeed);
                if (Quaternion.Angle(transform.rotation, originalRotation) < 1f) // Reduced threshold for smoother transition
                {
                    isDistracted = false;
                }
            }
        }
    }

    public void TriggerDistraction(Transform pointOfInterest)
    {
        if (pointOfInterest != null)
        {
            Debug.Log("Distraction triggered at: " + pointOfInterest.position);
            distractionPoint = pointOfInterest;
            isDistracted = true;
            distractionTimer = distractionDuration;
        }
        else
        {
            Debug.Log("Point of Interest is null");
        }
    }
}
