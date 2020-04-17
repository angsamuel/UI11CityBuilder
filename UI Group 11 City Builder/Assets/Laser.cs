using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public CustomGrabber cg;
    public TerrainCube currentCube;

    public GameObject start;
    public GameObject end;

    void Update(){
        List<GameObject> hitties = new List<GameObject>();
        List<RaycastHit> hits;
        hits = new List<RaycastHit>(Physics.RaycastAll(start.transform.position,end.transform.position));
        for (int i = 0; i < hits.Count; i++){
            if(hits[i].transform.GetComponent<TerrainCube>()){
                if(hits[i].transform.GetComponent<TerrainCube>().surfaceCube){
                    currentCube = hits[i].transform.GetComponent<TerrainCube>(); 
                    i = hits.Count;
                }
            }
        }
    }

    // void OnTriggerEnter(Collider other){
    //     Debug.Log("TRIGGERED");
    //     if(other.GetComponent<TerrainCube>() != null && other.GetComponent<TerrainCube>().surfaceCube){
    //         currentCube = other.GetComponent<TerrainCube>();
    //     }
    // }
    // void OnTriggerExit(Collider other){
    //     if(other.GetComponent<TerrainCube>() != null && other.GetComponent<TerrainCube>().surfaceCube){
    //         if(other.GetComponent<TerrainCube>() == currentCube){
    //             currentCube = null;
    //         }
    //     }
    // }
}
