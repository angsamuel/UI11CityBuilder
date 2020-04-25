using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public int timeMins;
    public int timeSecs;

    public GameManager gm;

    private float timeLeft;
    private bool timesUp = false;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = timeMins * 60 + timeSecs;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0 && !timesUp)
        {
            GameOver();
            timesUp = true;
        }
    }

    void GameOver()
    {
        score += gm.pop;
        Debug.Log("Time's up!");
        Debug.Log("Score = " + score);
    }
}
