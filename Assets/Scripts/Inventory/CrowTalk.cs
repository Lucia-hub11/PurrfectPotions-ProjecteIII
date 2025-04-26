using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrowTalk : MonoBehaviour
{
    public GameObject crowTalkCanvas;
    private void Start(){
        crowTalkCanvas.SetActive(false);
    }
    public void ShowCrowTalk()
    {
        crowTalkCanvas.SetActive(true);
        Invoke("HideCrowTalk", 5f);
    }

    public void HideCrowTalk()
    {
        crowTalkCanvas.SetActive(false);
    }
}