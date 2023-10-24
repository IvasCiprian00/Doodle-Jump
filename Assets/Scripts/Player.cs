using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private BoxCollider2D legsCollider;

    [SerializeField]
    private GameObject propeller;

    [SerializeField]
    private GameObject jetpack;

    [SerializeField]
    private BoxCollider2D boxCollider;

    public bool isAscending = false;


    private void Start()
    {
        legsCollider = GameObject.Find("Legs").GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Movement();
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
            legsCollider.enabled = false;
        }
        else
        {
            legsCollider.enabled = true;
        }
    }

    public void StartJump(bool condition)
    {
        isAscending = condition;
        StartCoroutine(EndJump());
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }

        if (col.gameObject.tag == "Propeller")
        {
            Destroy(col.gameObject);
            StartCoroutine(CollectPropeller());
        }

        if (col.gameObject.tag == "Jetpack")
        {
            Destroy(col.gameObject);
            jetpack.SetActive(true);
        }
    }
    IEnumerator EndJump()
    {
        float pastPosition;

        while (true)
        {
            pastPosition = transform.position.y;
            yield return new WaitForSeconds(0.01f);
            if (pastPosition > transform.position.y)
            {
                break;
            }
        }
        isAscending = false;
    }

    IEnumerator CollectPropeller()
    {
        yield return new WaitForSeconds(0.5f);
        propeller.SetActive(true);
        boxCollider.enabled = false;
        //float propellerDuration = 0f;
        for(int i = 0; i < 10; i++)
        {
            transform.Translate(transform.up);
            yield return new WaitForSeconds(0.01f);
            //propellerDuration += Time.deltaTime;
            //Debug.Log(propellerDuration);
        }
        boxCollider.enabled = true;
        propeller.SetActive(false);
    }
}
