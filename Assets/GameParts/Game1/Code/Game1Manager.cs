using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Game1Manager : MonoBehaviour
{
    public enum gameState
    {
        playing,
        won,
        lost
    }
    public static gameState state;
    public  Slider timerSlider;
    Timer timer;
    public static int numbOfBricks = 7;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("The start timer is called");
        PlayerPrefs.SetInt("NumberOfLives", 3);
        PlayerPrefs.SetInt("GameNumber", 1);
        state = gameState.playing;
        timer = timerSlider.GetComponent<Timer>();
        timer.setTime(60);
        timerSlider.maxValue = 60;
        timerSlider.value = timerSlider.maxValue;
        PlayerPrefs.SetInt("numberOfBricks", numbOfBricks);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state == gameState.lost)
        {
            PlayerPrefs.SetInt("NumberOfLives", PlayerPrefs.GetInt("NumberOfLives") - 1);
            
            //timer.setTime(60);
            
            SceneManager.LoadScene("Life");
            
        }
         if(PlayerPrefs.GetInt("numberOfBricks") == 0)
        {
            SceneManager.LoadScene("Life");
        }
    }
       
    
}
