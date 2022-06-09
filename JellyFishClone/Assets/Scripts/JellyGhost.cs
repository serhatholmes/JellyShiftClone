using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyGhost : MonoBehaviour
{
    public static JellyGhost instance;
    public Transform[] ghostPoses;

    private int index = 0;
   
   private void Awake() {
       if(instance == null){
           instance = this;
       }
   }

   public void ChangeScaleOfGhost(Vector3 scale){
       scale.y *= 2;
       transform.localScale = scale;
   }

   public void ChangePosOfGhost()
   {
       index++;
       if(ghostPoses.Length >index){
           transform.position = ghostPoses[index].transform.position;
       }
   }
}
