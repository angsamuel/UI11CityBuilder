using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingObj;
    private Building thisBuilding;
    private GameObject bldgModel;

    // Start is called before the first frame update
    void Start()
    {
        thisBuilding = buildingObj.GetComponent<Building>();

        this.GetComponent<MeshFilter>().mesh = buildingObj.GetComponent<MeshFilter>().sharedMesh;
        this.GetComponent<MeshRenderer>().material = buildingObj.GetComponent<MeshRenderer>().sharedMaterial;

        bldgModel = buildingObj.transform.GetChild(0).gameObject;
        Instantiate(bldgModel, this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
