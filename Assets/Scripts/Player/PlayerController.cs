using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Part of input")]
    [SerializeField] private PlayerInput playerInput; ///Parte del input
    private Vector2 inputVector;  ///Parte del input

    [Header("Players Movement")]
    public float speed = 10.0f;

    public Rigidbody2D rb;
    [SerializeField]public SpriteRenderer spriteRenderer;

    [Header("Animaciones")]
    private Animator anim;
    private int playerMovementID;
    private int playerAttackID;
    [SerializeField] private bool isAttack;

     #region  Singleton
    private static PlayerController instance = null;

    // Game Instance Singleton
    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AnimacionesSetup(); //Iniciamos animaciones setup
    }

    void FixedUpdate()
    {
        Movement();
    }
    #region Parte del input
    void OnMovement(InputValue valor)
    {
        Vector2 inputMovement = valor.Get<Vector2>();
        inputVector = new Vector2(inputMovement.x, 0);
    }
    void OnAttack(InputValue valor)
    {
        if (valor != null)
        {
            Atacar();
            isAttack = true;
        }  
    }
    #endregion
    void AnimacionesSetup()
    {
        playerAttackID = Animator.StringToHash("Attack");
        playerMovementID = Animator.StringToHash("X");
    }
    void Atacar()
    {
        anim.SetTrigger(playerAttackID);
        

    }


    void Movement()
    {
        rb.velocity = inputVector * speed * Time.deltaTime;
        anim.SetFloat(playerMovementID, inputVector.x); //llamamos a la animacion de movimiento y con .sqrMagnitude la volvemos float
        if (inputVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (inputVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
   
}
