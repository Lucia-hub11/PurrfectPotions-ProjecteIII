using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lock : MonoBehaviour
{
    public bool Interactable = true;
    public GameObject LockCanvas;
    public TextMeshProUGUI[] Text;

    public Ingredient ingredient;

    public string Password;
    public string[] LockCharacterChoices;
    public int[] _lockCharacterNumber;
    public string _insertedPassword;

    public Animator cofreAnimator;
    public Animator diamondAnimator;
    public GameObject candau;
    public GameObject interactText;

    void Start()
    {
        _lockCharacterNumber = new int[Password.Length];
        UpdateUI();
    }
    public void ChangeInsertedPassword(int number)
    {
        _lockCharacterNumber[number]++;
        if(_lockCharacterNumber[number] >=LockCharacterChoices[number].Length)
        {
            _lockCharacterNumber[number] = 0;
        }
        CheckPassword();
        UpdateUI();
    }

    private void CheckPassword()
    {
        int pass_len = Password.Length;
        _insertedPassword = "";
        for(int i=0;i<pass_len;i++)
        {
            _insertedPassword += LockCharacterChoices[i][_lockCharacterNumber[i]].ToString();
        }
        if(Password == _insertedPassword)
        {
            Unlock();
        }
    }
    public void Unlock()
    {
        Debug.Log("Unlocked");
        cofreAnimator.SetBool("OpenCofre", true);
        
        diamondAnimator.SetBool("DiamondFloat", true);
        Destroy(candau);

        Invoke("WaitForDiamond", 2f);

        LockCanvas.SetActive(false);
        Destroy(interactText);
    } 

    private void WaitForDiamond()
    {
        
        
        ingredient.CollectIngredient();
    }

    private void UpdateUI()
    {
        int len = Text.Length;
        for(int i = 0;i<len;i++)
        {
            Text[i].text = LockCharacterChoices[i][_lockCharacterNumber[i]].ToString();
        }
    }
    public void StopInteract()
    {
        LockCanvas.SetActive(false);
    }
}
