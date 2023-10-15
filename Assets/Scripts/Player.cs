using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody2D;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float speed;

    [SerializeField]
    private BoxCollider2D boxCollider2D;

    private bool isAscending = false;
    void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            rigidBody2D.velocity = new Vector2(0f, 0f);
            rigidBody2D.AddForce(transform.up * jumpForce);
            StartJump(true);
        }
    }


    void Movement()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow)) {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if(transform.position.x < -3.62f)
        {
            transform.position = new Vector3(3.62f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 3.62f)
        {
            transform.position = new Vector3(-3.62f, transform.position.y, transform.position.z);
        }

        if (isAscending)
        {
            boxCollider2D.enabled = false;
        }
        else
        {
            boxCollider2D.enabled = true;
        }
    }

    void StartJump(bool condition)
    {
        isAscending = condition;
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        float pastPosition;

        while (true)
        {
            pastPosition = transform.position.y;
            yield return new WaitForSeconds(0.01f);
            if(pastPosition > transform.position.y)
            {
                break;
            }
        }
        isAscending = false;
    }
}
