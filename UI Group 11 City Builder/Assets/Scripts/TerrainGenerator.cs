using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Generation Prefabs")]
    public GameObject terrain_cube; //prefab to be spawned in

    [Header("Building Prefabs")]
    public GameObject tree_patch;

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
        return surface_cubes[x,z];
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

    //this method places initial buildings such as trees, and rivers
    public void PlaceNature(){
        //generate coordinates
        List<Vector2> coordinates = new List<Vector2>();
        for(int x = 0; x<map_size; x++){
            for(int z = 0; z<map_size; z++){
                coordinates.Add(new Vector2(x,z));
            }
        }

        //place trees
        int trees_to_place = (int)(tree_coverage_percentage * map_size * map_size);
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
        }
        return true;
    }
}
