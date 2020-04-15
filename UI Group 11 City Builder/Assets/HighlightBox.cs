using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightBox : MonoBehaviour
{
    public GameObject model;
    public Color greenColor;
    public Color redColor;
    public Color whiteColor;

    void Start(){
        Clear();
    }

    public void Clear(){
        model.transform.localScale = new Vector3(0,500,0);
    }
    public void Highlight(TerrainCube tc, Building b){
        transform.position = tc.transform.position;
        model.transform.localScale = new Vector3(1,500,1);
        if(b.BuildingConstraintsSatisfied(tc.x,tc.z)){
            model.GetComponent<Renderer>().material.color = greenColor;
        }else{
            model.GetComponent<Renderer>().material.color = redColor;
        }
    }

    public void Highlight(TerrainCube tc){
        transform.position = tc.transform.position;
        model.transform.localScale = new Vector3(1,500,1);
        model.GetComponent<Renderer>().material.color = whiteColor;
    }
}
