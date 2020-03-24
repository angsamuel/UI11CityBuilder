using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectBuilding : Building
{
    [Header("Sections")]
    public GameObject north_object;
    public GameObject south_object;
    public GameObject east_object;
    public GameObject west_object;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ConnectToNeighbors(bool from_master){
        List<Building> nsew_buildings = game_manager.GetNSEWBuildings(x_coord,z_coord);
        List<TerrainCube> surface_blocks = game_manager.GetNSEWSurfaceBlocks(x_coord,z_coord);
        if(surface_blocks[0] == null || nsew_buildings[0] != null){
            north_object.SetActive(true);
            if(from_master && nsew_buildings[0] != null && nsew_buildings[0].building_name == building_name){
                nsew_buildings[0].GetComponent<ConnectBuilding>().ConnectToNeighbors(false);
            }
        }
        if(surface_blocks[1] == null || nsew_buildings[1] != null){
            south_object.SetActive(true);
            if(from_master && nsew_buildings[1] != null && nsew_buildings[1].building_name == building_name){
                nsew_buildings[1].GetComponent<ConnectBuilding>().ConnectToNeighbors(false);
            }
        }
        if(surface_blocks[2] == null || nsew_buildings[2] != null){
            east_object.SetActive(true);
            if(from_master && nsew_buildings[2] != null && nsew_buildings[2].building_name == building_name){
                nsew_buildings[2].GetComponent<ConnectBuilding>().ConnectToNeighbors(false);
            }
        }
        if(surface_blocks[3] == null || nsew_buildings[3] != null){
            west_object.SetActive(true);
            if(from_master && nsew_buildings[3] != null && nsew_buildings[3].building_name == building_name){
                nsew_buildings[3].GetComponent<ConnectBuilding>().ConnectToNeighbors(false);
            }
        }
    }
    public override void ActivateBuilding(){
        //check terrain generator for buildings in adjacent slots, activate nsew pieces
        ConnectToNeighbors(true);
    }
}
