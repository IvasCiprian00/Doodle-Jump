using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PelletScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.Translate(transform.up * speed *  Time.deltaTime);

        if(transform.position.y >= cam.transform.position.y + 7f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x >= cam.transform.position.x + 6f)
        {
            Destroy(gameObject);
        }
        if (transform.position.x <= cam.transform.position.x + -6f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Debug.Log("LEGO");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
