using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : EntityClass
{
    [SerializeField]
    private GameObject background;

    private void Start()
    {
        background = GameObject.Find("Background");
    }

    void Update()
    {
        this.SetDespawnThreshold(background.transform.position.y - 5.5f);
        this.CheckDespawnThreshold();
    }
}
