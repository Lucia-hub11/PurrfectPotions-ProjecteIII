using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExteriorAInterior : MonoBehaviour
{
	public Transform player, destination;
	public GameObject playerGO;
	public GameObject IngredientsInventory;
    public GameObject ObjectsInventory;


    void OnTriggerEnter(Collider other){
	  if(other.CompareTag("Player")){
		  playerGO.SetActive(false);
		  player.position = destination.position;
		  playerGO.SetActive(true);
            IngredientsInventory.SetActive(true);
            ObjectsInventory.SetActive(false);

        }
  }
}
