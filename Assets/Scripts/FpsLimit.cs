using UnityEngine;

public class FpsLimit : MonoBehaviour
{
    void Start()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = 30;
    }
}