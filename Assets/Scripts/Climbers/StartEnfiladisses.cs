using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnfiladisses : MonoBehaviour
{
    public Canvas climbers;
    public CameraSwitcher camSwitch;

    void Start()
    {
        climbers.enabled = false; 
    }

    public void JocEnfiladisses()
    {
        climbers.enabled = true;
       
        if (camSwitch != null)
        {
            Debug.Log("Cambiando a FollowingCam");
            camSwitch.SwitchToFollowing();
        }
        else
        {
            Debug.LogWarning("StartEnfiladisses: cameraSwitcher no asignado");
        }
    }
}
