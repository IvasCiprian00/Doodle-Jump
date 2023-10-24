using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : EntityClass
{
    void Update()
    {
        this.SetDespawnThreshold(background.transform.position.y - 5.4f);
        this.CheckDespawnThreshold();
    }

}
