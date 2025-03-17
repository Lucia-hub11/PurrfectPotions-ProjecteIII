using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorAExterior : MonoBehaviour
{
   public Transform player, destination;
  public GameObject playerGO;

  void OnTriggerEnter(Collider other){
	  if(other.CompareTag("Player")){
		  playerGO.SetActive(false);
		  player.position = destination.position;
		  playerGO.SetActive(true);
	  }
  }
}
