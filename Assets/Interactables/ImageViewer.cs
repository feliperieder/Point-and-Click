using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : Interactable
{

    [SerializeField] Sprite sprite;
    public override void Interact()
    {
        GameManager.instance.ivCanvas.Activate(sprite);
    }

}
