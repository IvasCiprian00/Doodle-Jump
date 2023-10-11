using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody2D;

    [SerializeField]
    private float jumpForce;

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name == "Platform")
        {
            rigidBody2D.AddForce(transform.up * jumpForce);
        }
    }
}
