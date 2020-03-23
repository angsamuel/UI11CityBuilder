using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : ConnectBuilding
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool BuildingConstraintsSatisfied(int x, int z){
        List<Building> nsew_buildings = game_manager.GetNSEWBuildings(x, z);
        foreach(Building b in nsew_buildings){
            if(b != null && (b.building_name == building_name || b.building_name == "City Center")){
                return true;
            }
        }
        return false;
    }
}
