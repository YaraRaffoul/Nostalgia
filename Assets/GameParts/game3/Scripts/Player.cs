using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float shipAcceleration = 10f;
    public float shipMaxVelocity = 10f;
    public float shipRotationSpeed = 100f;

    private Rigidbody2D rigidbody2D;
    private bool isAlive = true;
    private bool isAccelerating = false;
    

    //public Transform BulletSpawn;
    public Rigidbody2D bulletPrefab;
    public float BulletSpeed = 8f;

    Vector3 viewportPosition;
    // Start is called before the first frame update
    void Start()
    {
        viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        Debug.Log("The player script is called");
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive)
        {
           
            HandleShipRotation();
            HandleShooting();
        }
        

    }
   
    

    void HandleShipRotation()
    {
        
        float rotationInput = Input.GetAxis("Horizontal");
        float rotationAmount = rotationInput * shipRotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, -rotationAmount);

        // Forward and Backward Movement: Up and Down Arrow keys (or W and S keys)
        float thrustInput = Input.GetAxis("Vertical");
        Vector3 thrustDirection = transform.up * thrustInput * shipAcceleration * Time.deltaTime;
        transform.Translate(thrustDirection, Space.World);
    }
    
       

    public void HandleShooting()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, transform.position, quaternion.identity);

            Vector2 shipVelocity = rigidbody2D.velocity;
            Vector2 shipDirection = transform.up;
            float shipForwardSpeed = Vector2.Dot(shipVelocity, shipDirection);

            if(shipForwardSpeed < 0)
                shipForwardSpeed = 0;
            
            bullet.velocity = shipDirection * shipForwardSpeed;
             
            bullet.AddForce(BulletSpeed * transform.up, ForceMode2D.Impulse);
        }
    }
}
