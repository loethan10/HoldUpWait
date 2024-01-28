using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public static BankManager instance;
    public int USD = 300;
    // public Deposit[] deposit;
    // public Text dollarText;
    public GameObject BankUI;

    public void Awake(){
        if(instance==null){
            instance=this;
        }else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void ToggleBank(){
        BankUI.SetActive(!BankUI.activeSelf);
    }
}
