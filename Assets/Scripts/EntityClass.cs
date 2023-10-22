using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityClass : MonoBehaviour
{
    private float despawnThreshold;

    public GameObject background;

    private void Start()
    {
        background = GameObject.Find("Background");
    }

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
