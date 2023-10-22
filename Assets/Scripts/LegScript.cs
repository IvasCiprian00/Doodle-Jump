using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegScript : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private Rigidbody2D playerRigidbody;

    [SerializeField]
    private float jumpForce;

    private void Start()
    {
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            playerRigidbody.velocity = new Vector2(0f, 0f);
            playerRigidbody.AddForce(transform.up * jumpForce);
            player.StartJump(true);
        }

        if(col.gameObject.tag == "Enemy_Head")
        {
            playerRigidbody.velocity = new Vector2(0f, 0f);
            playerRigidbody.AddForce(transform.up * jumpForce);
            player.StartJump(true);
            Destroy(col.transform.parent.gameObject);
        }
    }
}
