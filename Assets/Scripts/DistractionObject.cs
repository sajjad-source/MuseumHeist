using UnityEngine;

public class DistractionObject : MonoBehaviour
{
    public SecurityCamera targetCamera;
    public float effectiveRange = 10f;

    void OnCollisionEnter(Collision collision)
    {
        float distanceToCamera = Vector3.Distance(transform.position, targetCamera.transform.position);
        if (distanceToCamera <= effectiveRange)
        {
            Debug.Log("Triggering distraction, distance to camera: " + distanceToCamera);
            targetCamera.TriggerDistraction(transform);
        }
    }
}
