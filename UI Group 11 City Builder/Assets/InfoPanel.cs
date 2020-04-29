using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    public CustomGrabber cg;
    public Text buildingNameText;
    public Text buildingInfoText;
    public List<Text> resourceTexts;
    
    void Update(){
        if(cg.buildingPrefab != null){
            transform.localScale = Vector3.one;
            buildingNameText.text = cg.buildingPrefab.GetComponent<Building>().building_name;
            ClearResourceTexts();
            buildingInfoText.text = cg.buildingPrefab.GetComponent<Building>().description;
            FillResourceTexts(cg.buildingPrefab.GetComponent<Building>());
        }else{
            transform.localScale = Vector3.zero;
        }
        
        
        
        

    }

    void ClearResourceTexts(){
        for(int i = 0; i<resourceTexts.Count; i++){
            resourceTexts[i].text = "";
        }
    }

    void FillResourceTexts(Building b){
        int resourceIndex = 0;
        if(b.pop_cost > 0){
            FillResourceText(resourceIndex, "Population  (-" + b.pop_cost.ToString() + ")",Color.red);
            resourceIndex += 1;
        }else if(b.food_cost>0){
            FillResourceText(resourceIndex, "Food  (-" + b.food_cost.ToString() + ")",Color.red);
            resourceIndex += 1;
        }else if(b.wood_cost>0){
            FillResourceText(resourceIndex, "Wood  (-" + b.wood_cost.ToString() + ")",Color.red);
            resourceIndex += 1;
        }else if(b.ore_cost>0){
            FillResourceText(resourceIndex, "Ore  (-" + b.ore_cost.ToString() + ")",Color.red);
            resourceIndex += 1;
        }  
    }

    void FillResourceText(int i, string content, Color color){
        resourceTexts[i].color = color;
        resourceTexts[i].text = content;
    }
    
}
