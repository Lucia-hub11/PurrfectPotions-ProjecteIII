using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject mainCameraGO;    // El GameObject que tiene la Main Camera + AudioListener
    public GameObject staticCameraGO;  // El GameObject que tiene la Static Camera + AudioListener

    public AudioSource mainCameraMusic;   
    public AudioSource staticCameraMusic;

    private void Start()
    {
        if (mainCameraGO == null || staticCameraGO == null)
            Debug.LogError("CameraSwitcher: falta asignar cámaras en el Inspector");

        if (mainCameraMusic == null || staticCameraMusic == null)
        Debug.LogError("CameraSwitcher: falta asignar AudioSources en el Inspector");

        // Estado inicial
        mainCameraGO.SetActive(false);
        staticCameraGO.SetActive(true);

        staticCameraMusic.Play();
        mainCameraMusic.Stop();
    }

    public void SwitchToStatic()
    {
        Debug.Log("Canviant a StaticCamera");
        mainCameraGO.SetActive(false);
        staticCameraGO.SetActive(true);

        mainCameraMusic.Stop();
        staticCameraMusic.Play();
    }

    public void SwitchToMain()
    {
        Debug.Log("Canviant a mainCamera");
        staticCameraGO.SetActive(false);
        mainCameraGO.SetActive(true);

        staticCameraMusic.Stop();
        mainCameraMusic.Play();
    }

    public void PauseStaticMusic()
    {
        staticCameraMusic.Pause();
    }


    //public Camera mainCamera;
    //public Camera staticCamera;

    //private void Start()
    //{
    //    mainCamera.enabled = true;
    //    staticCamera.enabled = false;
    //}

    //public void SwitchToStatic()
    //{
    //    Debug.Log("Canvi a StaticCamera");
    //    mainCamera.enabled = false;
    //    staticCamera.enabled = true;
    //}

    //public void SwitchToMain()
    //{
    //    staticCamera.enabled = false;
    //    mainCamera.enabled = true;
    //}
}