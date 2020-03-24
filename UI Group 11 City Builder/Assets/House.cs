using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
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
        List<Building> surroundingBuildings = game_manager.GetSurroundingBuildings(x,z);
        for(int i = 0; i<surroundingBuildings.Count; i++){
            if(surroundingBuildings[i] != null){
                if(surroundingBuildings[i].GetComponent<Road>() != null || surroundingBuildings[i].GetComponent<CityCenter>() != null){
                    return true;
                }
            }
        }
        return false;
    }

    public override void ActivateBuilding(){
        game_manager.pop += 1;
    }
}
