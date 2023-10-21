using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityClass : MonoBehaviour
{
    private float despawnThreshold;

    public void SetDespawnThreshold(float threshold)
    {
        despawnThreshold = threshold;
    }

    public void CheckDespawnThreshold()
    {
        if(gameObject.transform.position.y < despawnThreshold)
        {
            Destroy(gameObject);
        }
    }
}
