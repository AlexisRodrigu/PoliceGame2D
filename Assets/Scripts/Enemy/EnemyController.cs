using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float visionRadius;
    [SerializeField] private float stopDistance = 1.0f;
    float dist;
    public GameObject player;
    public Vector2 initialPosition;
    #region  variables de animaciones

    Animator anim;
    private int enemyMovementID = Animator.StringToHash("X");
    private int enemyAttackID = Animator.StringToHash("Attack");
    private int enemyDieID = Animator.StringToHash("Die");
    AnimatorClipInfo[] clipInfo;
    float clipDuration;
    string clipName;

    #endregion
    private Rigidbody2D rbEnemy;
    private SpriteRenderer spriteRenEnemy;
    [Header("SPPLAYER")]
    public SpriteRenderer spPlayer;
    bool pasas;
    [Header("Min Distancia")]
    public float minDist;

    #region  Singleton
    private static EnemyController instance = null;

    // Game Instance Singleton

  
    #endregion
    void Start()
    {

        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        rbEnemy = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;

        spriteRenEnemy = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        Attack();
        FlipEnemy();
    }

    void Follow()
    {
        //Nuestro objetivo sera la posicion inicial
        Vector3 target = initialPosition;

        //SI LA DIRANCIA ES MENOR QUE EL RADIO DE VISION EL OBJETIVO SERA EL
        dist = Vector2.Distance(player.transform.position, transform.position);
        if (dist < visionRadius)
        {
            anim.SetFloat(enemyMovementID, 1); //Animacion
            target = player.transform.position;
        }


        //Movemos al enemigo al objetivo o target
        float fixedSpeed = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
        Debug.DrawLine(transform.position, target, Color.red);
    }
    //Dibuja el rango de vision de mi enemigo a mi jugador o al que le quiero pegar
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
      Gizmos.DrawLine(gameObject.transform.position, player.transform.position);

    }
    //Funcion atacar
    void Attack()
    {
        if (dist <= stopDistance)
        {
            speed = 0;
            anim.SetTrigger(enemyAttackID);

        }
        else
        {
            speed = 5;
        }

    }

    public void Die()
    {
        anim.SetBool(enemyDieID, true);
        Destroy(gameObject,1.2f);
        Debug.Log("<color=Black><b>" + "Mori" + "</b></color>");
    }
    
    private void FlipEnemy(){
     
        if(dist < minDist){
            pasas = !pasas;
        }
        if(pasas){
            spriteRenEnemy.flipX = false;
        }else{
            spriteRenEnemy.flipX = true;
        }    
    }
}


