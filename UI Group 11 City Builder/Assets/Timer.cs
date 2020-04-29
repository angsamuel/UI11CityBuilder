using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timerText;
    public Text scoreText;
    public int minutes = 5;//minutes
    int secondsLeft;
    public GameManager gameManager;

    public List<GameObject> thingsToHide;
    public GameObject splashScreen;


    void Start(){
        StartCountdown();
    }
    public void StartCountdown(){
        secondsLeft = minutes * 60;
        StartCoroutine(CountdownRoutine());
    }

    IEnumerator CountdownRoutine(){
        while(secondsLeft > 0){
            Debug.Log(secondsLeft);
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            timerText.text = (secondsLeft / 60).ToString() + ":" + (secondsLeft % 60).ToString();
        }
        timerText.text = "0:00";
        GameOver();
    }

    public void GameOver(){
        foreach(GameObject g in thingsToHide){
            g.transform.localScale = Vector3.zero;
        }
        scoreText.text = "You built a town for " + gameManager.pop.ToString() + " people!";
        splashScreen.transform.localScale = Vector3.one;
    }


}
