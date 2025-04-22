using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [Header("Arrastra las c�maras aqu�")]
    public Camera mainCamera;
    public Camera staticCamera;

    private void Start()
    {
        // Asegurarnos de empezar con la main activa y la est�tica desactivada
        mainCamera.enabled = true;
        staticCamera.enabled = false;
    }

    public void SwitchToStatic()
    {
        mainCamera.enabled = false;
        staticCamera.enabled = true;
    }

    public void SwitchToMain()
    {
        staticCamera.enabled = false;
        mainCamera.enabled = true;
    }
}