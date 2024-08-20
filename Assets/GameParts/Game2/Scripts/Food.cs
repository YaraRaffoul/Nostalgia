//using System;
using Unity.Collections;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D gridArea;
    void Start()
    {
        RandomizePosition();
    }

    Vector2 RandomizePosition()
    {
        Bounds bounds = this.gridArea.bounds;
        float x = Random.Range(bounds.min.x + 1, bounds.max.x - 1); 
        float y = Random.Range(bounds.min.y + 1, bounds.max.y - 1);
        
        return new Vector2(x, y);
    }

    void ChangeFoodPosition() {
        Vector2 pos = RandomizePosition();
        float x = pos.x;
        float y = pos.y;
        while(!Snake.checkForFoodPosition(x, y))
        {
            pos = RandomizePosition();
            x = pos.x;
            y = pos.y;
        }
        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Head")
        {
            int numberOfEatenFood = PlayerPrefs.GetInt("numberOfEatenFood");
            numberOfEatenFood++;
            PlayerPrefs.SetInt("numberOfEatenFood", numberOfEatenFood);

            ChangeFoodPosition();
            
        }
    }
    
}
