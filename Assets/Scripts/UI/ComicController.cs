using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ComicController : MonoBehaviour
{
    public List<Sprite> comicPanels;     
    public Image panelImage;                
    public VideoPlayer videoPlayer;      
    public GameObject imagePanel;                            

    private int currentPanel = 0;

    void Start()
    {
        imagePanel.SetActive(true);
        StartCoroutine(PlayComic());
    }

    IEnumerator PlayComic()
    {
        while (currentPanel < comicPanels.Count)
        {
                panelImage.sprite = comicPanels[currentPanel];
                if ((currentPanel<2 )||
                   (currentPanel>8 && currentPanel<12))
                {
                    yield return new WaitForSeconds(6f);
                }
                else
                {
                    yield return new WaitForSeconds(4f);
                }

                currentPanel++;
        }

        // Al terminar todas las viñetas
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}