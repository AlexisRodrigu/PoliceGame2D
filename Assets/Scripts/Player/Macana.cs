using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macana : MonoBehaviour
{
   public SpriteRenderer spriteRen;
   private BoxCollider2D boxColliderMacana;


   [SerializeField]GameObject bloodGO;
    private void Start() {
        spriteRen = GetComponentInParent<SpriteRenderer>();
        boxColliderMacana = GetComponent<BoxCollider2D>();
       
    }
    private void Update()
    {
        PositionPlayer();
    }
  private void OnTriggerEnter2D(Collider2D other) {
      if (other.gameObject.tag == "Enemy")
        {
            Instantiate(bloodGO,transform.position,transform.rotation);
          
        } 
   }
    private void PositionPlayer (){
        if(spriteRen.flipX == true){
            boxColliderMacana.offset = new Vector2(1f,0f)*(-1);
        }else{
             boxColliderMacana.offset = new Vector2(1f,0f) * Vector2.one;
        }
    }
}
