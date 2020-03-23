using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreDeposit : Building
{
    // Start is called before the first frame update
    public GameObject ore_block;
    public int min_blocks = 1;
    public int max_blocks = 5;
    public float min_h_scale = 0.15f;
    public float max_h_scale = .3f;
    public float min_y_scale = 0.25f;
    public float max_y_scale = 1f;
    void Start()
    {
        
        //spawn blocks
        int num_to_place = Random.Range(min_blocks,max_blocks+1);
        for(int i = 0; i<num_to_place; i++){
            GameObject newBlock = Instantiate(ore_block,transform);
            newBlock.transform.localScale = new Vector3(Random.Range(min_h_scale,max_h_scale),Random.Range(min_y_scale,max_y_scale),Random.Range(min_h_scale,max_h_scale));
            newBlock.transform.localPosition = new Vector3(Random.Range(-.3f,.3f),0.5f,Random.Range(-.3f,.3f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
