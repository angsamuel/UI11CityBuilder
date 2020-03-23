using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePatch : Building
{
    public GameObject tree;
    public int trees_to_spawn = 7;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        GeneratePatch();
    }

    void GeneratePatch(){
        for(int i = 0; i<trees_to_spawn; i++){
            GameObject newTree = Instantiate(tree,transform);
            newTree.transform.localPosition = new Vector3(Random.Range(-.4f,.4f),0.5f,Random.Range(-.4f,.4f));
            float randomScale = Random.Range(0.15f,0.5f);
            newTree.transform.localScale = new Vector3(randomScale,randomScale,randomScale);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
