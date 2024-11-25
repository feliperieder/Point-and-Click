using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using DG.Tweening;

public abstract class Node : MonoBehaviour
{


    public Transform cameraPosition;
    public List<Node> reachableNodes = new List<Node>();

    [HideInInspector]
    public Collider col;

    void Awake(){
        col = GetComponent<Collider>();
        col.enabled = false;
       
    }

    void OnMouseDown(){
        Arrive();
    }

    public virtual void Arrive(){
        if(GameManager.instance.currentNode != null){
        //abandonar nodo atual
            GameManager.instance.currentNode.Leave(); 
        }

        //Setar nodo atual
        GameManager.instance.currentNode = this;

        
        //Mover a câmera
        GameManager.instance.camRig.AllignTo(cameraPosition);


        //Desligar o próprio colisor
        if (col != null){
            col.enabled = false;
        }

        //ativar todos nodos em alcance
        SetReachableNodes(true);
    }

    public virtual void Leave(){
        //desativar todos nodos em alcance
        SetReachableNodes(false);
    }

    public void SetReachableNodes(bool set) {

        foreach (Node node in reachableNodes){
            if(node.col != null){
                if (node.GetComponent<Prerequesite>() && node.GetComponent<Prerequesite>().nodeAccess){
                    if (node.GetComponent<Prerequesite>().Complete){
                        node.col.enabled = set;
                    }
                }
                else{
                    node.col.enabled = set;
                }   
            }
        }

    }
}
