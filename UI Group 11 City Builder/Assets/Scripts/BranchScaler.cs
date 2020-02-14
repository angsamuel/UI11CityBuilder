using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchScaler : MonoBehaviour
{
    public float scale = 0.5f;
    public void Generated(int index){
       
       transform.localScale *= scale;
       
   }
}
