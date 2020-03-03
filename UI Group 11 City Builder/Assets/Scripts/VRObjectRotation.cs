using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRObjectRotation : MonoBehaviour
{
        //sensativity
    [Header("Customization")]
    public float xSensativity;
    public float ySensativity;

    public string axisToActivateRotation;

    [Header("Helper Objects")]
    public GameObject controlObject; //object which is used as reference for rotation
    public GameObject objectToRotate;

    //tracking variables
    Vector3 cachedPosition; //cached position of the control object
    bool rotating = true;

    void Start(){
        cachedPosition = controlObject.transform.localPosition;
    }


    void FixedUpdate(){
        if(Input.GetAxisRaw(axisToActivateRotation) != 0){
            rotating = true;
        }else{
            rotating = false;
        }
        if(rotating){
            Vector3 delta = cachedPosition - controlObject.transform.localPosition;
            objectToRotate.transform.Rotate(Vector3.up, delta.x * ySensativity, Space.World);
            objectToRotate.transform.Rotate(Vector3.right, -delta.y * xSensativity, Space.World);
            cachedPosition = controlObject.transform.localPosition;
        }else{
            cachedPosition = controlObject.transform.localPosition;
        }
    }



}
