using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Laser : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float laserDistance = 10f;
    public LayerMask ignoreMask;
    public UnityEvent OnHitTarget;
    public AudioSource alarm;

    private RaycastHit rayHit;
    private Ray ray;
    private bool alarmTriggered = false;

    void Update()
    {
        ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out rayHit, laserDistance, ~ignoreMask))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, rayHit.point);

            if (rayHit.collider.CompareTag("Player") && !alarmTriggered)
            {
                OnHitTarget?.Invoke();
                alarm.Play();
                alarmTriggered = true;
            }
        }
        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserDistance);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * laserDistance);

        if (rayHit.collider != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(rayHit.point, 0.2f);
        }
    }
}
