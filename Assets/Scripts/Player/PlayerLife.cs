using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{
    [SerializeField] private float initialLife = 100;
    [SerializeField] private float life;
    [SerializeField] private bool playerIsAlive;
    private int damage = 10;
    public Slider slider;
    void Start()
    {
        life = initialLife;
        playerIsAlive = true;
        
    }
    private void Update()
    {
        slider.value = life;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "WeaponEnemy"){
            PlayerIsPunch();
        }
   }
    public void PlayerIsPunch(){
      if(life > 0)
      {
          life -= damage;
            slider.value = life;
        }
      if(life <= 0){
          playerIsAlive = false;
    Destroy(gameObject);
      } 
    }
   
}
