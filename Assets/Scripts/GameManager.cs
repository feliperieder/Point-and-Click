using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    [HideInInspector]
    public Node currentNode;

    public CameraRig camRig; 

    public Node startingNode;

    public IVCanvas ivCanvas;

    public ObsCamera obsCamera; 

    public Item itemHeld = null;
    public InventoryDisplay inventoryDisplay;

    void Awake(){
        instance = this;
        ivCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
    }   

    void Start(){
        startingNode.Arrive() ;
    }

    void Update(){
        if (Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null){
            if (ivCanvas.gameObject.activeInHierarchy){
                ivCanvas.Close();
                return;
            }
            if (obsCamera.gameObject.activeInHierarchy){
                obsCamera.Close();
                return;
            }
            currentNode.GetComponent<Prop>().location.Arrive();
        }
    }
}
