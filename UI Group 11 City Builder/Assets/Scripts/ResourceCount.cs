using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResourceCount : MonoBehaviour
{
    public Text woodCountText;
    public Text oreCountText;
    public Text foodCountText;
    public Text moneyCountText; 
    public Text populationCountText;
    GameManager gameManager;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        woodCountText.text = gameManager.wood.ToString();
       oreCountText.text = gameManager.ore.ToString();
        foodCountText.text = gameManager.food.ToString();
        moneyCountText.text = gameManager.money.ToString();
       populationCountText.text = gameManager.pop.ToString();
    }

}