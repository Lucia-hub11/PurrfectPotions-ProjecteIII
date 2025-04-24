using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorAInterior : MonoBehaviour
{
	public Transform player, destination;
	public GameObject playerGO;
	public GameObject IngredientsInventory;
    public GameObject ObjectsInventory;

	//Refer�ncia al script de gesti� del canvi de c�meres
	public CameraSwitcher cameraSwitcher;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entr� al trigger de ExteriorAInterior");

        if (other.CompareTag("Player"))
        {
            playerGO.SetActive(false);
            player.position = destination.position;
            playerGO.SetActive(true);
            IngredientsInventory.SetActive(true);
            ObjectsInventory.SetActive(false);

            if (cameraSwitcher != null)
            {
                Debug.Log("Cambiando a StaticCamera");
                cameraSwitcher.SwitchToStatic();
            }
            else
            {
                Debug.LogWarning("ExteriorAInterior: cameraSwitcher no asignado");
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Revertir inventarios
        IngredientsInventory.SetActive(false);
        ObjectsInventory.SetActive(true);

        // Volver a Main
        if (cameraSwitcher != null)
        {
            Debug.Log("Volviendo a MainCamera");
            cameraSwitcher.SwitchToMain();
        }
    }
}

