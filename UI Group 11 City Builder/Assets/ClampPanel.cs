using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampPanel : MonoBehaviour
{
    public Image panel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        panel.transform.position = pos;
    }
}
