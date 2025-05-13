using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public bool Interactable = true;
    public GameObject LockCanvas;
    public Text[] Text;

    public string Password;
    public string[] LockCharacterChoices;
    public int[] _lockCharacterNumber;
    public string _instertedPassword;

    void Start()
    {
        
    }
}
