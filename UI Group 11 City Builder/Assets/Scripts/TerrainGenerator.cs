using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Generation Prefabs")]
    public GameObject terrain_cube; //prefab to be spawned in

    [Header("Building Prefabs")]
    public GameObject tree_patch;
    public GameObject river;

    [Header("Preferences")]
    public Color bottom_color;
    public Color mid_color;
    public Color surface_color;

    [Range(0,1)]
    public float tree_coverage_percentage;

    //Trackers
    int map_size = 0;
    TerrainCube[,] surface_cubes; //2D array containing cubes on top of terrain
    Building[,] surface_buildings;
    // Start is called before the first frame update
    void Awake()
    {
        GenerateTerrain(9);
        PlaceNature();
        
    }

    //method for accessing cubes on the top of the terrain
    public TerrainCube GetSurfaceCube(int x, int z){
        if(x > -1 && x < map_size){
            if(z > -1 && z < map_size){
                return surface_cubes[x,z];
            }
        }
        return null;
        
    }

    //Generation function, spans in cubes into a cube shape with sepcified direction,
    void GenerateTerrain(int size){
        if(size < 3){
            size = 3; //ensure we don't break coloring
        }
        map_size = size;
        surface_cubes = new TerrainCube[size,size];
        surface_buildings = new Building[size,size];
        for(int x = 0; x<size; x++){
            for(int y = 0; y < size; y++){
                for(int z = 0; z<size;z++){
                    GameObject newterrain_cube = Instantiate(terrain_cube,transform);
                    float trueSize = size - 1;
                    newterrain_cube.transform.localPosition = new Vector3(x,y,z) - new Vector3((float)(size-1)/2,(float)(size-1)/2,(float)(size-1)/2);
                    //color cubes based on height
                    
                    if(y<=size/2){
                        newterrain_cube.GetComponent<Renderer>().material.color = 
                            Color.Lerp(bottom_color,mid_color,(float)y/((float)trueSize/2));
                    }else{
                          newterrain_cube.GetComponent<Renderer>().material.color = 
                            Color.Lerp(mid_color,surface_color,((float)y-((float)trueSize/2))/((float)trueSize/2));;
                    }

                    if(y == size -1){
                        surface_cubes[x,z] = newterrain_cube.GetComponent<TerrainCube>(); //save cubes on the surface for reference later
                    }
                }
            }
        }
    }

    public List<Vector2> DirectionList(){
        List<Vector2> direction_list = new List<Vector2>();
        direction_list.Add(new Vector2(0,1));
        direction_list.Add(new Vector2(0,-1));
        direction_list.Add(new Vector2(1,0));
        direction_list.Add(new Vector2(-1,0));
        return direction_list;
    }

    //this method places initial buildings such as trees, and rivers
    public void PlaceNature(){
        //generate coordinates
        List<Vector2> coordinates = new List<Vector2>();
        for(int x = 0; x<map_size; x++){
            for(int z = 0; z<map_size; z++){
                coordinates.Add(new Vector2(x,z));
            }
        }

        //draw river
        Vector2 river_position = new Vector2(0,0);
        Vector2 river_velocity = new Vector2(0,0);
        int river_start_choice = Random.Range(0,4);
        switch(river_start_choice){
            case 0: //N
                river_position = new Vector2(map_size/2, map_size - 1);
                river_velocity = new Vector2(0,-1);
                break;
            case 1: //S
                river_position = new Vector2(map_size/2, 0);
                river_velocity = new Vector2(0,1);
                break;
            case 2: //E
                river_position = new Vector2(map_size-1,map_size/2);
                river_velocity = new Vector2(-1,0);
                break;
            case 3: //W
                river_position = new Vector2(0,map_size/2);
                river_velocity = new Vector2(1,0);
                break;
            default: //?
                break;
        }

        int max_rivers = map_size * map_size / 4;
        int river_steps = 2;
        for(int i = 0; i<max_rivers; i++){
            PlaceBuilding(river,(int)river_position.x,(int)river_position.y);
            coordinates.Remove(river_position);
            river_position += river_velocity;
            if(river_position.x < 0 || river_position.x > map_size -1){
                break;
            }
            if(river_position.y < 0 || river_position.y > map_size -1){
                break;
            }
            //change flow direction
            if(i > 0 && i % river_steps == 0){
                Vector2 new_river_velocity = DirectionList()[Random.Range(0,4)];
                if(new_river_velocity != -river_velocity){
                    river_velocity = new_river_velocity;
                }
            }
            
            
        }



        //place trees
        int trees_to_place = (int)(tree_coverage_percentage * coordinates.Count);
        for(int i = 0; i<trees_to_place; i++){
            int selected_index = Random.Range(0,coordinates.Count);
            Vector2 coordinate = coordinates[selected_index];
            int x = (int)coordinate.x;
            int z = (int)coordinate.y;
            coordinates.RemoveAt(selected_index);
            PlaceBuilding(tree_patch,x,z);
        }

    }

    public bool CanPlaceBuilding(int x, int z){
        return surface_buildings[x,z] == null;
    }
    //USE THIS METHOD TO PLACE A BUILDING
    public bool PlaceBuilding(GameObject building_prefab,int x, int z){
        if(!CanPlaceBuilding(x,z)){
            return false;
        }
        else{
            GameObject newBuilding = Instantiate(building_prefab,surface_cubes[x,z].transform);
            surface_buildings[x,z] = newBuilding.GetComponent<Building>();
            newBuilding.GetComponent<Building>().SetMaster(x,z,this);
            newBuilding.GetComponent<Building>().ActivateBuilding();

        }
        return true;
    }

    public Building GetBuilding(int x, int z){
        if(x < surface_buildings.GetLength(0) && x >= 0){
            if(z < surface_buildings.GetLength(1) && z >= 0){
                return surface_buildings[x,z];
            }
        }
        return null;
    }
    //returns list of adjacent buildings in north, south, east, west order    
    public List<Building> GetNSEWBuildings(int x, int z){
        List<Building> return_list = new List<Building>();
        return_list.Add(GetBuilding(x,z+1));
        return_list.Add(GetBuilding(x,z-1));
        return_list.Add(GetBuilding(x+1,z));
        return_list.Add(GetBuilding(x-1,z));
        return return_list;
    }
    public List<TerrainCube> GetNSEWSurfaceBlocks(int x, int z){
        List<TerrainCube> return_list = new List<TerrainCube>();
        return_list.Add(GetSurfaceCube(x,z+1));
        return_list.Add(GetSurfaceCube(x,z-1));
        return_list.Add(GetSurfaceCube(x+1,z));
        return_list.Add(GetSurfaceCube(x-1,z));
        return return_list;
    }
}
