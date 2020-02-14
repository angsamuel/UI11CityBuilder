
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchRotator : MonoBehaviour
{
    public float rotation_angle = 30f;
    public void Generated(int index){
       
       this.transform.rotation *= Quaternion.Euler(rotation_angle * ((index * 2) -1),0,0);
       
   }
}
