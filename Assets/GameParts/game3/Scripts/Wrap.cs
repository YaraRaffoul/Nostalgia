using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    public GameObject leftEdge;
    public GameObject rightEdge;
    public GameObject upEdge;
    public GameObject downEdge;
    public float offset = 0.24f;

    void Start()
    {
        Debug.Log("The edge start is called");
        leftEdge = GameObject.FindWithTag("LeftEdge");
        rightEdge = GameObject.FindWithTag("RightEdge");
        upEdge = GameObject.FindWithTag("UpEdge");
        downEdge = GameObject.FindWithTag("DownEdge");
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "LeftEdge" || other.tag == "RightEdge" || other.tag == "UpEdge" || other.tag == "DownEdge")
        {
            Vector3 moveAdjustement = Vector3.zero;
        
            if(other.tag == "LeftEdge")
            {
                moveAdjustement.x = rightEdge.transform.position.x + offset;
            }
            if(other.tag == "RightEdge")
            {
                moveAdjustement.x = leftEdge.transform.position.x - offset;
            }
            if(other.tag == "UpEdge")
            {
                moveAdjustement.y = downEdge.transform.position.y + offset;
            }
            if(other.tag == "DownEdge")
            {
                moveAdjustement.y = upEdge.transform.position.y -  offset;
            }
        
            transform.position = moveAdjustement;
        }
    }
}

