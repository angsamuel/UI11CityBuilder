using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacementTester : MonoBehaviour
{
    public GameManager gm;
    public GameObject road;
    public GameObject house;

    // Start is called before the first frame update
    void Start()
    {
        
        for(int i = 0; i<15; i++){
            gm.PlaceBuilding(road,gm.map_size/2 + i,gm.map_size/2);
            gm.PlaceBuilding(road,gm.map_size/2 - i,gm.map_size/2);
            gm.PlaceBuilding(road,gm.map_size/2,gm.map_size/2 + i);
            gm.PlaceBuilding(road,gm.map_size/2,gm.map_size/2 - i);
        }
        gm.PlaceBuilding(house,gm.map_size/2+1,gm.map_size/2+1);
        gm.PlaceBuilding(house,gm.map_size/2-1,gm.map_size/2-1);
        gm.PlaceBuilding(house,gm.map_size/2+1,gm.map_size/2-1);
        gm.PlaceBuilding(house,gm.map_size/2-1,gm.map_size/2+1);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
