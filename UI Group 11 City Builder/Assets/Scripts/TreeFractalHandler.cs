using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeFractalHandler : MonoBehaviour
{
    public int depth = 5;
    public int split = 2;
    // Start is called before the first frame update
    void Start()
    {
        depth -= 1;
        for(int i = 0; i<split; i++){
            if(depth > 0){
                GameObject copy_tree = Instantiate(gameObject);
                TreeFractalHandler copy_fractal_handler = copy_tree.GetComponent<TreeFractalHandler>();
                copy_fractal_handler.SendMessage("Generated", i);
            }
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
