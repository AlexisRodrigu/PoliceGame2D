using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TxtScore : MonoBehaviour
{


    public GameObject player;
    public static int score;
    private int initialScore = 0;
     public static int  maxScore = 2;
    TxtScore scoreScript;

    private TextMeshProUGUI txtScore;
    void Start()
    {
        txtScore = GetComponent<TextMeshProUGUI>();
        scoreScript = this;
        
        maxScore = PlayerPrefs.GetInt("PuntajeMaximo", 0);//Almacena el puntaje
    }
  
    public  void ScoreAdd()
    {
        score++;
       txtScore.text = "0"+score;
    }

}
