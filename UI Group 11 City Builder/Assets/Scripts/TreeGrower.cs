using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{
   public void Generated(int index){
        this.transform.position += transform.up * transform.localScale.y;
   }
}
