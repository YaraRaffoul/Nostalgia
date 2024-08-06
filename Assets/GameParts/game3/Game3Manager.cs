using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game3Manager : MonoBehaviour
{
    public enum gameState
    {
        playing,
        won,
        lost
    }
    public gameState state;
    public  Slider timerSlider;
    //Start is called before the first frame update
    void Start()
    {
        state = gameState.playing;
        PlayerPrefs.SetInt("GameNumber", 3);
        timerSlider.maxValue = 60;
    }

   // Update is called once per frame
    void Update()
    {
         if(state == gameState.lost)
        {
            PlayerPrefs.SetInt("NumberOfLives", PlayerPrefs.GetInt("NumberOfLives") - 1);
            SceneManager.LoadScene("Life");
            
        }
    }
}
