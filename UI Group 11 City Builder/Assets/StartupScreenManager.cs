using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StartupScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text welcomeText;
    public Text instructionText;
    public GameObject cube;
    ScreenFader screenFader;
    void Start()
    {
        screenFader = GameObject.Find("ScreenFader").GetComponent<ScreenFader>();
        cube.SetActive(false);
        welcomeText.color = Color.clear;
        instructionText.color = Color.clear;
        StartCoroutine(InitialRoutine());
    }

    // Update is called once per frame
    IEnumerator InitialRoutine(){
        yield return new WaitForSeconds(1f);
        float t = 0;
        while(t<2f){
            t+=Time.deltaTime;
            yield return null;
            welcomeText.color = new Color(1,1,1,t/2);
        }
        welcomeText.color = Color.white;
        t = 0;
        while(t<2f){
            t+=Time.deltaTime;
            yield return null;
            instructionText.color = new Color(1,1,1,t/2);
        }
        instructionText.color = Color.white;
        cube.SetActive(true);
    }

    public IEnumerator ToMainMenu(){
        yield return null;
        instructionText.color = Color.clear;
        welcomeText.text = "Nice!";
        instructionText.text = "You're all set. Enjoy your game.";
        float t = 0;
        while(t<2f){
            t+=Time.deltaTime;
            yield return null;
            instructionText.color = new Color(1,1,1,t/2);
        }
        StartCoroutine(screenFader.FadeToBlack());
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene("MainMenu");
    }
}
