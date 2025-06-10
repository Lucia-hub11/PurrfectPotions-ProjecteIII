using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public GameObject inventoryCanvas;
    public GameObject mapCanvas;

    public AudioSource audioSource;

    private void Start()
    {
        if(inventoryCanvas==null || mapCanvas == null)
        {
            Debug.LogError("Inventory o Map canvas no estan asignados");
        }
        inventoryCanvas.SetActive(false);
        mapCanvas.SetActive(false);
    }

    public void ToggleInventory()
    {
        //bool isOpen = inventoryCanvas.activeSelf;
        //inventoryCanvas.SetActive(!isOpen);

        //Si se acaba de abrir el inventario, se cierra el mapa
        //if(!isOpen)
        //{
        //    mapCanvas.SetActive(false);
        //}
        bool wasOpen = inventoryCanvas.activeSelf;
        bool newState = !wasOpen;

        // Aplicar estados
        inventoryCanvas.SetActive(newState);
        mapCanvas.SetActive(false);

        Debug.Log("No es detecta el Inventory Canvas");

        PlayUIClickSound();
    }

    public void ToggleMap()
    {
        //bool isOpen = mapCanvas.activeSelf;
        //mapCanvas.SetActive(!isOpen);

        //Si se acaba de abrir el mapa, se cierra el inventario

        //if (!isOpen)
        //{
        //    inventoryCanvas.SetActive(false);
        //}

        bool wasOpen = mapCanvas.activeSelf;
        bool newState = !wasOpen;

        // Aplicar estados
        mapCanvas.SetActive(newState);
        inventoryCanvas.SetActive(false);

        Debug.Log("No detecta el canvasMap");

        PlayUIClickSound();
    }

    //Funcions per tancar per botó individual de canvas
    public void CloseInventory()
    {
        inventoryCanvas.SetActive(false);
        PlayUIClickSound();
    }

    public void CloseMap()
    {
        mapCanvas.SetActive(false);
        PlayUIClickSound();
    }

    private void PlayUIClickSound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    //public void ShowInventory()
    //{
    //    inventoryCanvas.SetActive(true);
    //    mapCanvas.SetActive(false);
    //}
    //public void ShowMap()
    //{
    //    mapCanvas.SetActive(true);
    //    inventoryCanvas.SetActive(false);
    //}
}
