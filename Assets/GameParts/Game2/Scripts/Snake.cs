using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject tailPrefab;
    private static List<Transform> tail = new List<Transform>();
    private Vector2 direction;
    private bool ate = false;
    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;
    public BoxCollider2D gridArea;

    void Start()
    {
        direction = Vector2.up;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    void Update()
    {
        if(tail.Count == 0)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
                //direction = Vector2.right;
            }
                
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
                //direction = Vector2.left;
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                //direction = Vector2.up;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                //direction = -Vector2.down;
                spriteRenderer.transform.rotation = Quaternion.Euler(0, 0, 180);
                
            }
                
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if(transform.rotation != Quaternion.Euler(0, 0, 90))
                {
                    transform.rotation = Quaternion.Euler(0, 0, -90);
                //direction = Vector2.right;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if(transform.rotation != Quaternion.Euler(0, 0, -90))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 90);
                //direction = Vector2.left;
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                //direction = Vector2.up;
                if(transform.rotation != Quaternion.Euler(0, 0, 180))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                if(transform.rotation != Quaternion.Euler(0, 0, 0))
                {
                    transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                //direction = Vector2.down;
            }
        }
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(direction);

        if (ate)
        {
            GameObject g = Instantiate(tailPrefab, v, Quaternion.identity);
            g.tag = "Tail";
            tail.Insert(0, g.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            tail[tail.Count - 1].position = v; 
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Food")
        {
            ate = true;
            
        }
        if (other.gameObject.tag == "Tail")
        {
            Debug.Log("tail Game over!");
            Game2Manager.state = Game2Manager.gameState.lost;
        }
    }
    public static bool checkForFoodPosition(float x, float y){
        for(int i = 0; i < tail.Count; i++) 
        {
            if((tail[i].position.x == x) && (tail[i].position.y == y))
            {
                return false;
            }
        }
        return true;
    }
    private  void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Barrier")
        {
            Debug.Log("Game over!");
            Game2Manager.state = Game2Manager.gameState.lost;
        }
    }
}
