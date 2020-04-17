using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : Building
{

    public override void ActivateBuilding(){
        game_manager.food += 1;
        List<Building> adjacentBuildings = game_manager.GetSurroundingBuildings(x_coord,z_coord);
        foreach(Building b in adjacentBuildings){
            if(b != null){
                if(b.GetComponent<River>() != null){
                    game_manager.food += 1;
                }
            }
        }
        
    }
    //ensure buiding can be placed according to unique rules
    public override bool BuildingConstraintsSatisfied(int x, int z){
        List<Building> buildingsCloseBy = game_manager.GetBuildingsInRadius(x,z,3);
        foreach(Building b in buildingsCloseBy){
            if(b != null){
                if(b.GetComponent<Road>() != null || b.GetComponent<CityCenter>() != null){
                    return true;
                }
            }
            
        }
        return false;
    }
}
