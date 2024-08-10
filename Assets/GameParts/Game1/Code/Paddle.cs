using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 5f;
    public float maxX = 7.5f;
    float horizontal;
    private Camera camera;
    private Rigidbody2D rigidbody;
    Vector2 screenPosition;
    float posY; 
     SpriteRenderer SRenderer;
    // Start is called before the first frame update
    
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        
        SRenderer = GetComponent<SpriteRenderer>();
        PlayerPrefs.SetFloat("PaddleYPos", transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        

        float leftLimit = Camera.main.ViewportToWorldPoint(new Vector3(0, 0f, Camera.main.nearClipPlane)).x;
        float rightLimit = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, Camera.main.nearClipPlane)).x;
        float width = SRenderer.bounds.extents.x;
        if(transform.position.x - width< leftLimit)
        {
            transform.position = new Vector2(leftLimit + width, transform.position.y);
        }
        if(transform.position.x + width > rightLimit)
        {
            transform.position = new Vector2(rightLimit - width, transform.position.y);
        }
        if(transform.position.x - width>= leftLimit && transform.position.x + width <= rightLimit)
        {
         transform.position += Vector3.right * horizontal * speed * Time.deltaTime;
        }
        PlayerPrefs.SetFloat("PaddleXPos",transform.position.x);
    }
}
