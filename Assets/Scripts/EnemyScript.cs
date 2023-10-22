using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyScript : EntityClass
{
    void Update()
    {
        this.SetDespawnThreshold(background.transform.position.y - 5.5f);
        this.CheckDespawnThreshold();
    }
}
