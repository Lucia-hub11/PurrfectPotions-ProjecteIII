using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrowTalk : MonoBehaviour
{
    public GameObject crowTalkCanvas;
    public GameObject crowThanks;
    private void Start(){
        crowTalkCanvas.SetActive(false);
        crowThanks.SetActive(false);
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

    public void ShowCrowThanks()
    {
        crowThanks.SetActive(true);
        Invoke("HideCrowThanks", 4f);
    }

    public void HideCrowThanks()
    {
        crowThanks.SetActive(false);
    }
}