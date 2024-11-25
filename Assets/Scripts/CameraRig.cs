using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRig : MonoBehaviour
{

    public Transform y_axis;
    public Transform x_axis;
    [SerializeField]private float moveTime = 0.75f;

    public void AllignTo(Transform target){
        //Mover a câmera
        Sequence sequence = DOTween.Sequence();
        sequence.Append(y_axis.DOMove(target.position, moveTime));
        sequence.Join(y_axis.DORotate(new Vector3(0f, target.rotation.eulerAngles.y, 0f), moveTime));
        sequence.Join(x_axis.DOLocalRotate(new Vector3(target.rotation.eulerAngles.x, 0f, 0f), moveTime));


        //Camera.main.transform.position = cameraPosition.position;
        //Camera.main.transform.rotation = cameraPosition.rotation;

    }
}
