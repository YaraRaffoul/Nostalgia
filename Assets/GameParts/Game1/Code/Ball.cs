using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float minY = -5.5f;
    Rigidbody2D rigidbody2D;
    public float maxVelocity = 15f;
    public bool ballTakeOff = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(PlayerPrefs.GetFloat("PaddleXPos"), PlayerPrefs.GetFloat("PaddleYPos") + 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(!ballTakeOff) 
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("PaddleXPos"), PlayerPrefs.GetFloat("PaddleYPos") + 1);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("The space button is pressed");
                rigidbody2D.AddForce(Vector3.up * 1000);
                ballTakeOff = true;
            }
        }
        if(transform.position.y < PlayerPrefs.GetFloat("PaddleYPos"))
        {
            // rigidbody2D.velocity = Vector3.zero;
            // transform.position = Vector3.zero;
            // Debug.Log("Passed the paddle");
            Game1Manager.state = Game1Manager.gameState.lost;
            
        }
        if(rigidbody2D.velocity.magnitude > maxVelocity)
        {
            rigidbody2D.velocity = Vector3.ClampMagnitude(rigidbody2D.velocity, maxVelocity);
        }
    }
}
