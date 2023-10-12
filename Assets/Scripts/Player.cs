using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Platform")
        {
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
        yield return new WaitForSeconds(0.5f);
        isAscending = false;
    }
}
