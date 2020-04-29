using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeMusicIn());
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator FadeMusicIn(){
        yield return null;
        float t= 0;
        while(t<1f){
            t+=Time.deltaTime;
            GetComponent<AudioSource>().volume = t;
            yield return null;
        }
    }
}
