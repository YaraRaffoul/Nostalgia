 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Game2Manager : MonoBehaviour
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
    public float gameTime = 60; 
    int totalNumberOfFood = 7;
    private  bool timerIsStopped;
    private  float time;
    public TextMeshProUGUI FoodText;
    // Start is called before the first frame update
    void Start()
    {
        timerSlider.maxValue = 60;
        PlayerPrefs.SetInt("numberOfEatenFood", 0);
        FoodText.text = PlayerPrefs.GetInt("numberOfEatenFood") + "/" + totalNumberOfFood;
    }

    // Update is called once per frame
    void Update()
    {
        
            if(state == gameState.lost)
            {
                PlayerPrefs.SetInt("NumberOfLives", PlayerPrefs.GetInt("NumberOfLives") - 1);
                //SceneManager.LoadScene("Life");
                StartCoroutine(MoveToNextScene());
            }

            FoodText.text = PlayerPrefs.GetInt("numberOfEatenFood") + "/" + totalNumberOfFood;

             if(PlayerPrefs.GetInt("numberOfEatenFood") == totalNumberOfFood)
            {
                StartCoroutine(MoveToNextScene());
            }
    }
     IEnumerator MoveToNextScene()
    {
        float pauseDuration = 3f;
        // Pause the game
        Time.timeScale = 0;

        // Wait for the specified duration
        yield return new WaitForSecondsRealtime(pauseDuration);

        // Resume the game
        Time.timeScale = 1;

        // Load the new scene
        SceneManager.LoadScene("Life");
    }
}
