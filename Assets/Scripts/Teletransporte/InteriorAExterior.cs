using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorAExterior : MonoBehaviour
{
   public Transform player, destination;
  public GameObject playerGO;
    public GameObject IngredientsInventory;
    public GameObject ObjectsInventory;

    public CameraSwitcher cameraSwitcher;

    void OnTriggerEnter(Collider other){
	  if(other.CompareTag("Player")){
		  playerGO.SetActive(false);
		  player.position = destination.position;
		  playerGO.SetActive(true);
          //IngredientsInventory.SetActive(false);
          //ObjectsInventory.SetActive(true);

            if (cameraSwitcher != null)
            {
                Debug.Log("Cambiando a MainCamera");
                cameraSwitcher.SwitchToMain();
            }
            else
            {
                Debug.LogWarning("InteriorAExterior: cameraSwitcher no asignado");
            }
        }
    }
}
