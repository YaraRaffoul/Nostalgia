using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;    

public class Timer : MonoBehaviour
{
    public  Slider timerSlider; 
    public float gameTime; 
    private  bool timerIsStopped;
    private  float time;
    // Start is called before the first frame update
    public void Start()
    {
       timerIsStopped = false; 
       
        //PlayerPrefs.SetInt("timerIsStopped", 0);

        int timerIsStoppedInt = PlayerPrefs.GetInt("timerIsStopped");
        Debug.Log(timerIsStoppedInt == 0);

        //Debug.Log(PlayerPrefs.GetInt("timerIsStopped"));
        //PlayerPrefs.SetFloat("gameTime", 60);
        //gameTime = PlayerPrefs.GetFloat("gameTime");
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
    }

    // Update is called once per frame
    void Update()
    {
        
            
            time += Time.deltaTime;
            //Debug.Log(Time.time);
            timerSlider.value = time;
            
        
        
        if(time >= gameTime)
        {
            Debug.Log("Timer exceeds");
            //timerIsStopped = true;
            //PlayerPrefs.SetInt("timerIsStopped", 1);
            //Debug.Log(PlayerPrefs.GetInt("timerIsStopped"));
            
        }
        
    }
    public  void setTime(float newTime) 
    {
        gameTime = newTime;
        timerSlider.value = newTime;
        Debug.Log("Set time is called");
    }
    public  void startTime() 
    {
        timerIsStopped = false;
    }
    public  void stopTime() 
    {
        Destroy(timerSlider);

    }
    
}
