using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : EntityClass
{
    void Update()
    {
        this.SetDespawnThreshold(background.transform.position.y - 5f);
        this.CheckDespawnThreshold();
    }
}
