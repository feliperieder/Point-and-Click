using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    Text displayText;

    void Start(){
        displayText = GetComponent<Text>();
        UpdateDisplay();     

    }

    public void UpdateDisplay(){
        string displayName;
        if (GameManager.instance.itemHeld != null){
            displayName = GameManager.instance.itemHeld.itemName;
        }
        else{
            
            Debug.Log("Test");
            displayName = "Nenhum Item";
        }
        displayText.text = "Item: "+ displayName;
    }
}
