using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementBlock : MonoBehaviour
{
    public GameObject buildingPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if(buildingPrefab != null){
            Instantiate(buildingPrefab,transform);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
