using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string building_name;
    protected int x_coord = -1;
    protected int z_coord = -1;

    protected TerrainGenerator terrain_generator;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaster(int x, int z, TerrainGenerator tg){
        //set block as slave to master terrain generator
        x_coord = x;
        z_coord = z;
        terrain_generator = tg;
    }
    public virtual void ActivateBuilding(){
        //set building as 
        
    }
}
