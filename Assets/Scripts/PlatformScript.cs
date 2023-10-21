using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : EntityClass
{
    [SerializeField]
    private GameObject background;


    private void Start()
    {
        background = GameObject.Find("Background");
    }
    void Update()
    {
        this.SetDespawnThreshold(background.transform.position.y - 5f);
        this.CheckDespawnThreshold();
    }
}
