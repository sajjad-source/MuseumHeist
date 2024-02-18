using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnOnOpenFloor : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public GameObject heistSetupPrefab;
    public PlaneClassification planeClassification;

    private bool spawned = false;

    private void OnEnable()
    {
        planeManager.planesChanged += CheckPlanes;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= CheckPlanes;
    }

    private void CheckPlanes(ARPlanesChangedEventArgs obj)
    {
        if (!spawned)
        {
            foreach (var plane in obj.added)
            {
                if (plane.classification == planeClassification)
                {
                    Vector3 spawnPosition = plane.transform.position;
                    spawnPosition.y -= 0.25f; // Adjust this value as needed

                    Instantiate(heistSetupPrefab, spawnPosition, Quaternion.identity);
                    spawned = true;
                    break;
                }
            }
        }
    }
}
