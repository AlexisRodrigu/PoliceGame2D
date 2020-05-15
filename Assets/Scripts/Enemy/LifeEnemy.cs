using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeEnemy : MonoBehaviour
{
   
    [SerializeField] private float initialLife = 100;
    [SerializeField] private float life;

    [SerializeField]private bool isAlive;
    public EnemyController enemyControllerScript;

    void Start()
    {
        life = initialLife;
        isAlive = true;
        enemyControllerScript = GetComponent<EnemyController>();   
    }

  private void OnTriggerEnter2D(Collider2D other) {
       if( other.gameObject.tag == "Weapon"){
          Punch();  
      }
 }
  void Punch(){
      if(life > 0)
      {
          life -= 30;
      }
      if(life <= 0){
          isAlive = false;
          enemyControllerScript.Die();          
      }
  }
}
