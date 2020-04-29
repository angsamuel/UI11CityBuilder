using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginCube : MonoBehaviour
{
    bool primed = false;
    public string sceneToMoveTo;
    public ScreenFader screenFader;
    StartupScreenManager ssm;
    void Start()
    {
        ssm = GameObject.Find("StartupScreenManager").GetComponent<StartupScreenManager>();
        screenFader = GameObject.Find("ScreenFader").GetComponent<ScreenFader>();
    }

    // Update is called once per frame
    bool triggered = false;
    void Update()
    {
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0 && primed && !triggered){
            triggered = true;
            StartCoroutine(ssm.ToMainMenu());
            transform.localScale = Vector3.zero;
            
        } 
    }


    void OnTriggerEnter(Collider other){
        if(other.tag == "Hand"){
            primed = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.tag == "Hand"){
            primed = false;
        }
    }
}
