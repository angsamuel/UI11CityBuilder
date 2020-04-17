using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCenter : Building
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ActivateBuilding(){
        game_manager.wood += 10;
        game_manager.ore += 10;
        game_manager.food += 10;
    }


}
