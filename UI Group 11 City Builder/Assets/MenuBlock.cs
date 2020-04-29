using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBlock : MonoBehaviour
{
    // Start is called before the first frame update
    bool primed = false;
    public string sceneToMoveTo;
    public ScreenFader screenFader;
    void Start()
    {
        screenFader = GameObject.Find("ScreenFader").GetComponent<ScreenFader>();
    }

    // Update is called once per frame
    bool triggered = false;
    void Update()
    {
        if(OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger, OVRInput.Controller.Touch) > 0 && primed && !triggered){
            triggered = true;
            StartCoroutine(screenFader.FadeToBlack());
            StartCoroutine(ChangeScene());
            
        } 
    }

    IEnumerator ChangeScene(){
        yield return new WaitForSeconds(1.25f);
        if(sceneToMoveTo == ""){
            Application.Quit();
        }
        SceneManager.LoadScene(sceneToMoveTo);
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
