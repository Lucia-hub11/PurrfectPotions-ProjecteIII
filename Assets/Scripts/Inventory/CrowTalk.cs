using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CrowTalk : MonoBehaviour
{
    public GameObject crowTalkCanvas;
    public GameObject crowThanks;
    public AudioSource crowAudioSource;
    private void Start(){
        crowTalkCanvas.SetActive(false);
        crowThanks.SetActive(false);
    }
    public void ShowCrowTalk()
    {
        crowTalkCanvas.SetActive(true);
        PlayCrowAudio();
        Invoke("HideCrowTalk", 5f);
    }

    public void HideCrowTalk()
    {
        crowTalkCanvas.SetActive(false);
    }

    public void ShowCrowThanks()
    {
        crowThanks.SetActive(true);
        PlayCrowAudio();
        Invoke("HideCrowThanks", 4f);
    }

    public void HideCrowThanks()
    {
        crowThanks.SetActive(false);
    }

    private void PlayCrowAudio()
    {
        if (crowAudioSource != null && !crowAudioSource.isPlaying)
        {
            crowAudioSource.Play();
        }
    }
}