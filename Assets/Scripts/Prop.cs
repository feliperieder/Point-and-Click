using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : Node
{
    // Start is called before the first frame update
    public Location location;
    Interactable interactable;

    void Start(){
        interactable = GetComponent<Interactable>();
    }

    public override void Arrive()
    {
        if(interactable != null && interactable.enabled){
            interactable.Interact();
            return;
        }

        base.Arrive();

        //Tornar objeto interagivel se o prerequisito está de acordo
        if (interactable != null){
            if (GetComponent<Prerequesite>() && !GetComponent<Prerequesite>().Complete){
                return;
            }
            col.enabled = true;
            interactable.enabled = true; 
        }
    }

    public override void Leave()
    {
        base.Leave();

        if(interactable != null){
            interactable.enabled = false;
        }
    }

}
