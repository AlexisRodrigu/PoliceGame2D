using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    private float timeLife = 1.5f;
  private void Start() {
       DestroyBlood();
   }

   private void DestroyBlood(){
       Destroy(this.gameObject, timeLife);
   }

}
