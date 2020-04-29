using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    // Start is called before the first frame update
    public Image cover;
    void Start()
    {
        cover.transform.localScale = Vector3.one;
        StartCoroutine(FadeFromBlack());
    }

    IEnumerator FadeFromBlack(){
        float t= 0;
        yield return null;
        while(t<1f){
            t+=Time.deltaTime;
            cover.color = new Color(0,0,0,1f - t);
            yield return null;
        }
        cover.transform.localScale = Vector3.zero;
    }

    public IEnumerator FadeToBlack(){
        float t= 0;
         cover.transform.localScale = Vector3.one;
        yield return null;
        while(t<1f){
            t+=Time.deltaTime;
            cover.color = new Color(0,0,0,t);
            yield return null;
        }
        cover.color = Color.black;
        
    }
}
