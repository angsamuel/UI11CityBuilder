using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingObj;
    public Building thisBuilding;
    private GameObject bldgModel;
    //GameObject newBldg;

    public GameManager game_manager;

    // Start is called before the first frame update
    void Start()
    {
        thisBuilding = buildingObj.GetComponent<Building>();

        this.GetComponent<MeshFilter>().mesh = buildingObj.GetComponent<MeshFilter>().sharedMesh;
        this.GetComponent<MeshRenderer>().material = buildingObj.GetComponent<MeshRenderer>().sharedMaterial;
        bldgModel = buildingObj.transform.GetChild(0).gameObject;
        Instantiate(bldgModel, this.transform);

        //newBldg = Instantiate(buildingObj, this.transform);
        //newBldg.GetComponent<Renderer>().enabled = false;
        //Destroy(newBldg.GetComponent<Collider>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tryToPlaceThis()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("TerrainCube");
        TerrainCube closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach(GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go.GetComponent<TerrainCube>();
                distance = curDistance;
            }
        }
        
        Debug.Log("Found closest");

        if(distance <= 1 && closest.x != 0 && closest.z != 0)
        {
            Debug.Log("X: " + closest.x);
            Debug.Log("Z: " + closest.z);
            //Debug.Log("GameManager: " + game_manager == null);
            TerrainCube newCube = game_manager.GetSurfaceCube(closest.x, closest.z);
            
            if(newCube != null)
            {
                Debug.Log("Placing");
                //GameObject newBldg = Instantiate(buildingObj, this.transform.position, this.transform.rotation);
                if(!game_manager.PlaceBuilding(buildingObj, closest.x, closest.z))
                    Debug.Log("False!");
            }
        }
    }
}
