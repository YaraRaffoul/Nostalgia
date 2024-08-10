using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Snake : MonoBehaviour
{
    
    private Vector2 _direction = Vector2.right;
    [SerializeField]float speed = 5f;
    Rigidbody2D body;

    private List<Transform> _parts;

    public Transform partPrefab;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        _parts = new List<Transform>();
        _parts.Add(this.transform);
        SlowlyMove();
        Debug.Log(_parts.Count);
                //Time.fixedDeltaTime = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
       
        if(_parts.Count > 1)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) && !( _direction.y < 0))
            {
                _direction = Vector2.up;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow)&& !( _direction.y > 0))
            {
                _direction = Vector2.down;
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow)&& !( _direction.x > 0))
            {
                _direction = Vector2.left;
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow)&& !( _direction.x < 0))
            {
                _direction = Vector2.right;
            }
        }
        else 
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                _direction = Vector2.up;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                _direction = Vector2.down;
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _direction = Vector2.left;
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                _direction = Vector2.right;
            }
        }
        //body.velocity = new Vector3(_direction.x ,_direction.y, 0.0f)*speed;
        
    }

    

    void grow()
    {
        Transform part = Instantiate(this.partPrefab);
        part.tag = "Untagged";
        part.position = _parts[_parts.Count - 1].position;
        _parts.Add(part);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Food" && this.tag == "Snake")
        {
            //Invoke("grow",0.01f);
            grow();
        }
    }
    void SlowlyMove()
    {

        for(int i = _parts.Count - 1; i > 0; i--)
        {
           _parts[i].position = _parts[i - 1].position;
        } 

        transform.position = new Vector3
            (Mathf.Round(this.transform.position.x) + _direction.x,
             Mathf.Round(this.transform.position.y) + _direction.y,
             0.0f);
                
        Invoke("SlowlyMove",0.25f);
    }
}
