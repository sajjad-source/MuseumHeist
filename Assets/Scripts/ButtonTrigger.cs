using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public VRButton linkedButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands") || other.CompareTag("Player"))
        {
            linkedButton.OnButtonInteracted();
        }
    }
}
