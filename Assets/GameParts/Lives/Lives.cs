using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;
    public Button nextButton;
    // Start is called before the first frame update
    void Start()
    {
        
        nextButton.onClick.AddListener(nextButtonOnClick);
        if(PlayerPrefs.GetInt("NumberOfLives") == 2)
        {
            Destroy(life1);
        }
        else if(PlayerPrefs.GetInt("NumberOfLives") == 1)
        {
            Destroy(life1);
            Destroy(life2);
        }
        else if(PlayerPrefs.GetInt("NumberOfLives") == 0)
        {
            Destroy(life1);
            Destroy(life2);
            Destroy(life3);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void nextButtonOnClick(){
        int gameNumber = PlayerPrefs.GetInt("GameNumber");
        if(gameNumber == 1)
        {
            PlayerPrefs.SetInt("GameNumber",2);
            SceneManager.LoadScene("Game2");
        }
        if(gameNumber == 2)
        {
            PlayerPrefs.SetInt("GameNumber",3);
            SceneManager.LoadScene("Game3");
        }
        
    }
}
