using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Mathematics;
using UnityEditor;
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
    public float gameTime = 60f;
    public Asteroid prefab;

    public int nOfAsteroid = 0;
    public int level = 0;
    public PolygonCollider2D gridArea;
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
        //  if(state == gameState.lost)
        // {
        //     PlayerPrefs.SetInt("NumberOfLives", PlayerPrefs.GetInt("NumberOfLives") - 1);
        //     SceneManager.LoadScene("Life");
            
        //}
        if(nOfAsteroid == 0)
        {
            level++;
            int temp = 2 + (2 * level);
            for(int i = 0; i < temp; i++)
            {
                SpawnAsteroid();
            }
        }
    }

    public void SpawnAsteroid()
    {
        // Bounds bounds = this.gridArea.bounds;
        // float x = UnityEngine.Random.Range(bounds.min.x + 1, bounds.max.x - 1); 
        // float y = UnityEngine.Random.Range(bounds.min.y + 1, bounds.max.y - 1);
        // Vector2 spawnPosition = new Vector2(x,y);
        // Asteroid asteroid = Instantiate(prefab, spawnPosition, quaternion.identity);
        // nOfAsteroid++;
    }
}
