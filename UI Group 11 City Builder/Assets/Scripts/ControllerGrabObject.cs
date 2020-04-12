using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGrabObject : MonoBehaviour
{

    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grabAction;
    
    private GameObject collidingObject;
    private GameObject objectInHand;

    private bool bldgGrabbed = false;
    
    private void SetCollidingObject(Collider col)
    {
        
        if(collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        
        collidingObject = col.gameObject;
    }

    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);    
    }
    
    public void OnTriggerExit(Collider other)
    {
        if(!collidingObject)
            return;
        
        collidingObject = null;
    }

    private void GrabObject()
    {
        objectInHand = collidingObject;
        collidingObject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        if(GetComponent<FixedJoint>())
        {
            if(bldgGrabbed)
            {
                GetComponent<FixedJoint>().connectedBody = null;
                Destroy(GetComponent<FixedJoint>());
                objectInHand.SendMessage("tryToPlaceThis");
                Destroy(objectInHand);
                bldgGrabbed = false;
            }

            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            //objectInHand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            //objectInHand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }

        objectInHand = null;
    }

    //Update is called once per frame
    void Update()
    {
        if(grabAction.GetLastStateDown(handType))
        {
            if(collidingObject && collidingObject.tag != "BldgPlace")
            {
                Debug.Log("Grabbed non-bldg");
                GrabObject();
            }
            else if(collidingObject && collidingObject.tag == "BldgPlace" && !bldgGrabbed)
            {
                Debug.Log("Grabbed bldg");
                //Building bldg = collidingObject.GetComponent<Building>();
                GameObject newBldg = Instantiate(collidingObject, this.transform.position, collidingObject.transform.rotation, this.transform);
                collidingObject = newBldg;
                bldgGrabbed = true;
                GrabObject();
            }
        }

        if(grabAction.GetLastStateUp(handType))
        {
            if(objectInHand)
            {
                ReleaseObject();
            }
        }
    }
}
