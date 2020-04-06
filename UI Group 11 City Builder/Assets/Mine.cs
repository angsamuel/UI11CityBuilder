using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Building
{
    public virtual void ActivateBuilding(){
        List<Building> buildingsCloseBy = game_manager.GetBuildingsInRadius(x_coord,z_coord,1);
        foreach(Building b in buildingsCloseBy){
            if(b != null){
                if(b.GetComponent<OreDeposit>() != null){
                    game_manager.ore += 1;
                }
            }
        }
    }

    public virtual bool BuildingConstraintsSatisfied(int x, int z){
        bool hasRoad = false;
        bool farFromMine = true;
        List<Building> buildingsCloseBy = game_manager.GetBuildingsInRadius(x,z,1);
        foreach(Building b in buildingsCloseBy){
            if(b != null){
                if(b.GetComponent<Road>() != null || b.GetComponent<CityCenter>() != null){
                    hasRoad = true;
                }
            }
        }
        List<Building> possibleMines = game_manager.GetBuildingsInRadius(x,z,2);
        foreach(Building b in possibleMines){
            if(b != null){
                if(b.GetComponent<Mine>() != null){
                    farFromMine = false;
                }
            }
        }

        List<Building> possibleTrees = game_manager.GetBuildingsInRadius(x,z,2);
        foreach(Building b in possibleTrees){
            if(b != null){
                if(b.GetComponent<TreePatch>() != null){
                    Destroy(b.gameObject);
                }
            }
        }
        return hasRoad && farFromMine;
    }
}
