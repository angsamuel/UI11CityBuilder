using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    [Header("Prefabs")]
    public GameObject terrainCube; //prefab to be spawned in

    [Header("Preferences")]
    public Color bottomColor;
    public Color midColor;
    public Color surfaceColor;
    TerrainCube[,] surfaceCubes; //2D array containing cubes on top of terrain
    // Start is called before the first frame update
    
    void Awake()
    {
        GenerateTerrain(9,9,9);

    }

    //method for accessing cubes on the top of the terrain
    public TerrainCube GetSurfaceCube(int x, int z){
        return surfaceCubes[x,z];
    }

    //Generation function, spans in cubes into a cube shape with sepcified direction,
    void GenerateTerrain(int width, int height, int depth){
        if(height < 3){
            height = 3; //ensure we don't break coloring
        }
        surfaceCubes = new TerrainCube[width,depth];
        for(int x = 0; x<width; x++){
            for(int y = 0; y < height; y++){
                for(int z = 0; z<depth;z++){
                    GameObject newTerrainCube = Instantiate(terrainCube,transform);
                    float trueHeight = height - 1;
                    newTerrainCube.transform.localPosition = new Vector3(x,y,z) - new Vector3((float)(width-1)/2,(float)(height-1)/2,(float)(depth-1)/2);
                    //color cubes based on height
                    
                    if(y<=height/2){
                        newTerrainCube.GetComponent<Renderer>().material.color = 
                            Color.Lerp(bottomColor,midColor,(float)y/((float)trueHeight/2));
                    }else{
                          newTerrainCube.GetComponent<Renderer>().material.color = 
                            Color.Lerp(midColor,surfaceColor,((float)y-((float)trueHeight/2))/((float)trueHeight/2));;
                    }

                    if(y == height -1){
                        surfaceCubes[x,z] = newTerrainCube.GetComponent<TerrainCube>(); //save cubes on the surface for reference later
                    }
                }
            }
        }
    }
}
