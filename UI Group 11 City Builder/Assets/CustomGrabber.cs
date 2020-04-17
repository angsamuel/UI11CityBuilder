using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomGrabber : MonoBehaviour
{
    [Header("Trackers")]
    public GameObject potentialSelection;
    public GameObject storedBuilding;
    Vector3 buildingHoldMarkerScale;

    public GameObject buildingPrefab;
    public GameObject buildingVisual;


    [Header("Helpers")]
     public GameObject buildingHoldMarker;
     public Laser laser;
     public HighlightBox highlightBox;
     GameManager gm;
    //trackers
    bool canGrab = true;
    bool canPinch = true;

    float startSelectScale;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        buildingHoldMarkerScale = buildingHoldMarker.transform.localScale;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // if(OVRInput.GetDown(OVRInput.Button.One)){
        //     Debug.Log("A PRESSED");
        // }
        
         if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0 && canGrab){
             canGrab = false;
             if(potentialSelection != null && potentialSelection.GetComponent<PlacementBlock>().buildingPrefab != null){
                 if(buildingVisual != null){
                     Destroy(buildingVisual.gameObject);
                 }

                 //add it to hand
                 buildingPrefab = potentialSelection.GetComponent<PlacementBlock>().buildingPrefab;
                 buildingVisual = Instantiate(buildingPrefab,buildingHoldMarker.transform.position,Quaternion.identity);
                 buildingVisual.transform.parent = buildingHoldMarker.transform;
                 buildingVisual.transform.localScale = buildingHoldMarker.transform.localScale;
                 buildingVisual.transform.localScale = Vector3.one;
                 buildingVisual.transform.localEulerAngles = Vector3.zero;
                 
             }else{
                 Destroy(buildingVisual.gameObject);
                 buildingPrefab = null;
             }
        }else if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) == 0){
            canGrab = true;
        }
         
        if(buildingPrefab == null){
            buildingHoldMarker.transform.localScale = Vector3.zero;
            highlightBox.Clear();
        }else{
            buildingHoldMarker.transform.localScale = buildingHoldMarkerScale;
            if(laser.currentCube != null){
                highlightBox.Highlight(laser.currentCube,buildingVisual.GetComponent<Building>());
            }
        }


        if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) > 0 && canPinch){
             Debug.Log("PINCHING");
             canPinch = false;
             if(buildingPrefab != null && laser.currentCube != null){
                 gm.PlaceBuilding(buildingPrefab,laser.currentCube.x,laser.currentCube.z);
             }
         }else if(OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger, OVRInput.Controller.Touch) == 0){
             canPinch = true;
         }
         //;
    }

    public void Update(){
        //potentialSelection = null;
    }

    void OnTriggerStay(Collider other){
        if(other.GetComponent<PlacementBlock>()){
            if(potentialSelection != other.gameObject){
                potentialSelection = other.gameObject;
            }   
            
        }
    }
    
    
}
