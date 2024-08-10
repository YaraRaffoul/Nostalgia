using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D() {
        int numbOfBricks = PlayerPrefs.GetInt("numberOfBricks");
        numbOfBricks--;
        PlayerPrefs.SetInt("numberOfBricks", numbOfBricks);
        Debug.Log("collsion");
        Destroy(gameObject);
    }
}
