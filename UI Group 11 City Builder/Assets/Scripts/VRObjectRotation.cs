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


    void Update(){
        if(OVRInput.Get(OVRInput.Button.One)){
            rotating = true;
        }else{
            rotating = false;
        }
        if(Input.GetAxisRaw("Fire2") != 0){
            objectToRotate.transform.localEulerAngles = new Vector3(0,0,0);
            cachedPosition = new Vector3(0,0,0);
        }

        if(rotating){
            Vector3 delta = cachedPosition - controlObject.transform.localPosition;
            //if(delta.x < 1f && delta.y < 1f){
                objectToRotate.transform.Rotate(Vector3.up, delta.x * ySensativity, Space.World);
                objectToRotate.transform.Rotate(Vector3.right, -delta.y * xSensativity, Space.World);
            //}
        }
        cachedPosition = controlObject.transform.localPosition;
    }



}
