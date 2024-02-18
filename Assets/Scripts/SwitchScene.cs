using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Management;


public class SwitchScene : MonoBehaviour

{
    public ARSession arSession;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") || other.CompareTag("Player"))
        {
            arSession.enabled = false;
            XRGeneralSettings.Instance.Manager.StopSubsystems();
            XRGeneralSettings.Instance.Manager.DeinitializeLoader();
            SceneManager.LoadScene("VR", LoadSceneMode.Single);
        }
    }

}
