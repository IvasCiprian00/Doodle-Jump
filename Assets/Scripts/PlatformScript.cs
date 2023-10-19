using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField]
    private GameObject background;


    private void Start()
    {
        background = GameObject.Find("Background");
    }
    void Update()
    {
        if(background.transform.position.y - gameObject.transform.position.y > 5f)
        {
            Destroy(gameObject);
        }
    }
}
