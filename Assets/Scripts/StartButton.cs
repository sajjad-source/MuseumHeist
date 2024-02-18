using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnButtonPressed()
    {
        SceneManager.LoadScene("MainVR");
    }
}
