using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forester : Building
{
    // Start is called before the first frame update
    public override void ActivateBuilding(){
        List<Building> adjacentBuildings = game_manager.GetSurroundingBuildings(x_coord,z_coord);
        Debug.Log(adjacentBuildings.Count);
        foreach(Building b in adjacentBuildings){
            if(b != null){
                Debug.Log("GOT ONE");
                if(b.GetComponent<TreePatch>() != null){
                    Debug.Log("NEW WOOD");
                    game_manager.wood += 1;
                }
            }
        }
        
    }
    //ensure buiding can be placed according to unique rules
    public override bool BuildingConstraintsSatisfied(int x, int z){
        bool hasRoad = false;
        bool farFromForester = true;
        List<Building> buildingsCloseBy = game_manager.GetBuildingsInRadius(x,z,3);
        foreach(Building b in buildingsCloseBy){
            if(b != null){
                if(b.GetComponent<Road>() != null || b.GetComponent<CityCenter>() != null){
                    hasRoad = true;
                }
            }
        }
        List<Building> posibleForesters = game_manager.GetBuildingsInRadius(x,z,2);
        foreach(Building b in posibleForesters){
            if(b != null){
                if(b.GetComponent<Forester>() != null){
                    farFromForester = false;
                }
            }
        }
        return hasRoad && farFromForester;
    }
}
