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
    private float maximumSpawnInterval = 2f;

    [SerializeField]
    private float nextPlatformPosition = 0f;

    [SerializeField]
    private GameObject enemy;

    private float xPosition;

    private void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            if(nextPlatformPosition < background.transform.position.y)
            {
                nextPlatformPosition += Random.Range(1f, maximumSpawnInterval);
                if (background.transform.position.y < nextPlatformPosition)
                {
                    xPosition = Random.Range(-2.4f, 2.4f);
                    if (Random.Range(0, 10) == 1)
                    {
                        Instantiate(enemy, new Vector3(xPosition, background.transform.position.y + 5.8f, platform.transform.position.z), Quaternion.identity);
                    }
                    Instantiate(platform, new Vector3(xPosition, background.transform.position.y + 5.2f, platform.transform.position.z), Quaternion.identity);
                }
            }
        }
    }

}
