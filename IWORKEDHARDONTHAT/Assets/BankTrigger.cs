using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("PlayerFRFR")){
            BankManager.instance.ToggleBank();
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("PlayerFRFR")){
            BankManager.instance.ToggleBank();
        }
    }
}
