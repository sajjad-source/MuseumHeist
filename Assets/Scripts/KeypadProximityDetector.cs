using UnityEngine;

public class KeypadProximityDetector : MonoBehaviour
{
    public SimonSaysGame simonSaysGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            simonSaysGame.ActivateGame();
        }
    }
}
