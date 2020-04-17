using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public string building_name;
    protected int x_coord = -1;
    protected int z_coord = -1;

    [Header("Cost")]
    public int pop_cost;
    public int food_cost;
    public int wood_cost;
    public int ore_cost;
    public int money_cost;

    protected GameManager game_manager;
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    public void Awake()
    {
        game_manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetMaster(int x, int z, GameManager tg){
        //set block as slave to master terrain generator
        x_coord = x;
        z_coord = z;
        game_manager = tg;
    }
    //grant resources and activate effects
    public virtual void ActivateBuilding(){
        
        
    }
    //ensure buiding can be placed according to unique rules
    public virtual bool BuildingConstraintsSatisfied(int x, int z){
        return true;
    }

    public void PayForBuilding(){
        game_manager.pop -= pop_cost;
        game_manager.food -= food_cost;
        game_manager.wood -= wood_cost;
        game_manager.ore -= ore_cost;
        game_manager.money -= money_cost;
    }

    public bool CanPayForBuilding(){
        return game_manager.pop >= pop_cost &&
        game_manager.food >= food_cost &&
        game_manager.wood >= wood_cost &&
        game_manager.ore >= ore_cost &&
        game_manager.money >= money_cost;
    }

   
}
