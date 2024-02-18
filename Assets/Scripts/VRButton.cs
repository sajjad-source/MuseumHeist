using UnityEngine;

public class VRButton : MonoBehaviour
{
    public int buttonID;
    public Material defaultMaterial;
    public Material highlightMaterial;
    private Renderer buttonRenderer;

    private void Awake()
    {
        buttonRenderer = GetComponent<Renderer>();
        SetDefaultAppearance();
    }

    public void SetHighlightAppearance()
    {
        buttonRenderer.material = highlightMaterial;
    }

    public void SetDefaultAppearance()
    {
        buttonRenderer.material = defaultMaterial;
    }

    public void OnButtonInteracted()
    {
        SimonSaysGame.Instance.ButtonPressed(buttonID);
    }
}
