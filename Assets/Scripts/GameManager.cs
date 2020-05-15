using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public Transform playerTransform; //Jugador instanciado
    [SerializeField]

    #region  Singleton
    public static GameManager Instance
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

    private void Start()
    {
        InstanciaDePlayer();
    }

    private void InstanciaDePlayer()
    {
        Instantiate(playerTransform, new Vector2(-1.95f, -2.95f), Quaternion.identity);
    }
}
