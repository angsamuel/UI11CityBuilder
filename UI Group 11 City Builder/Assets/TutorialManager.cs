using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject world;
    public CustomGrabber cg;
    public GameObject buildingStuff;
    public Text tutorialText;
    ScreenFader screenFader;

    void Start(){
        buildingStuff.SetActive(false);
        StartCoroutine(TutorialRoutine());
        screenFader = GameObject.Find("ScreenFader").GetComponent<ScreenFader>();
    }
    IEnumerator TutorialRoutine(){
        yield return null;
        tutorialText.text = "Welcome to the tutorial.";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "The goal of this game is to build the largest town possible within the time limit";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "The more people living in your town, the higher your score.";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "First, let's show you how to rotate the world.";
        Vector3 cachedAngle = world.transform.eulerAngles;
        yield return new WaitForSeconds(5f);
        tutorialText.text = "Hold the A button on your controller, and move your hand.";
        yield return new WaitUntil(()=>cachedAngle != world.transform.eulerAngles);
        tutorialText.text = "Nice work!";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "Now let's place some buildings.";
        yield return new WaitForSeconds(5f);
        buildingStuff.SetActive(true);
        tutorialText.text = "You can grab buildings from the right side.";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "Try doing this now.";
        yield return new WaitUntil(()=>cg.buildingPrefab != null);
        tutorialText.text = "Nice!";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "You can place buildings by aiming at the surface of the world, and squeezing the trigger.";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "Buildings cost resources, but award them too.";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "Buildings can't be placed anywhere. Consult the panel for more info.";
        yield return new WaitForSeconds(5f);
        tutorialText.text = "This concludes the tutorial. Have a nice day :)";
        yield return new WaitForSeconds(5f);
        StartCoroutine(screenFader.FadeToBlack());
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("MainMenu");
        //yield return new WaitForSeconds(5f);
        //tutorialText.text = "You can grab buildings from the right side.";
        //yield return new WaitForSeconds(5f);
        //tutorialText.text = "You can grab buildings from the right side.";

        


    }
}
