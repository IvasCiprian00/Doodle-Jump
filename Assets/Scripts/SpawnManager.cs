using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private float maximumSpawnInterval = 0.3f;

    [SerializeField]
    private float nextPlatformPosition = 0f;

    private float xPosition;

    private void Update()
    {
        if(GameObject.Find("Player") != null)
        {
            Debug.Log("S");
            if(nextPlatformPosition < background.transform.position.y)
            {
                nextPlatformPosition += Random.Range(0.1f, maximumSpawnInterval);
                if (background.transform.position.y >= nextPlatformPosition)
                {
                    xPosition = Random.Range(-2.4f, 2.4f);
                    Instantiate(platform, new Vector3(xPosition, background.transform.position.y + 5.2f, platform.transform.position.z), Quaternion.identity);
                }
            }
        }
    }

}
