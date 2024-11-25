using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCamera : MonoBehaviour
{
    [HideInInspector] public Transform model;
    public Transform rig;
    public float sensitivity = 3f;

    Quaternion modelRot;
    Quaternion rigRot;

    void Update(){
        if ((Input.GetMouseButton(0)) && (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 )){
            if (model == null){
                return;
            }
            modelRot = model.rotation;
            rigRot = rig.rotation;
            ObjectRotation() ;
        } 
    }

    public void ObjectRotation(){
        float yRot = Input.GetAxis("Mouse X")* sensitivity;
        float xRot = Input.GetAxis("Mouse Y")* sensitivity;

        modelRot *= Quaternion.Euler(0f, -yRot, 0f);
        rigRot *= Quaternion.Euler(xRot, 0f, 0f);

        rigRot = ClampRotationAroundrigRot (rigRot);
        
        model.rotation = modelRot; 
        rig.rotation = rigRot;
        
    }

    Quaternion ClampRotationAroundrigRot(Quaternion q){
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        // Calcula o ângulo no eixo X
        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan2(q.x, q.w);
        // Limita o ângulo de rotação no eixo X
        angleX = Mathf.Clamp(angleX, -80f, 80f);

        // Atualiza o quaternion com o ângulo clamped
        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
        }

        public void Close(){
            Destroy(model.gameObject);
            rig.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
}
