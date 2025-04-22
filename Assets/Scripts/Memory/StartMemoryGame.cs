using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMemoryGame : MonoBehaviour
{
	public Canvas memory;
    private void Start()
    {
		memory.enabled = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			memory.enabled = true;
			GameObject cardsController = GameObject.Find("CardsController");
			ComportamentFiches fichesScript = cardsController.GetComponent<ComportamentFiches>();
			StartCoroutine(fichesScript.ShowCards());
		}
	}
}
