using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prerequesite : MonoBehaviour
{
    //checa através de um switcher
    public Switcher watchSwitcher;
    //Checa Através de um Item
    public bool requireItem;

    //Checa se precisa de uma chave
    public Collector checkCollector;
    
    public bool nodeAccess;

    public bool Complete{
        get{
            if(!requireItem){
                return watchSwitcher.state;
            }
            else{
                return  GameManager.instance.itemHeld.itemName == checkCollector.myItem.itemName;
            }


        }

    }
    
}
