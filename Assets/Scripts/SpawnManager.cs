using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private GameObject propeller;

    [SerializeField]
    private GameObject jetpack;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private float maximumSpawnInterval = 2f;

    [SerializeField]
    private float nextPlatformPosition = 0f;


    private float xPosition;

    private void Update()
    {
        if (GameObject.Find("Player") != null)
        {
            if(nextPlatformPosition < background.transform.position.y)
            {
                nextPlatformPosition += Random.Range(1f, maximumSpawnInterval);
                SpawnPlatform();
            }
        }

    }

    private void SpawnPlatform()
    {
        if (background.transform.position.y < nextPlatformPosition)
        {
            xPosition = Random.Range(-2.4f, 2.4f);
            float powerUpPosition = Random.Range(-0.3f, 0.3f);
            switch (Random.Range(0, 100))
            {
                case 0:
                    Instantiate(enemy, new Vector3(xPosition, background.transform.position.y + 5.6f, platform.transform.position.z), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(propeller, new Vector3(xPosition + powerUpPosition, background.transform.position.y + 5.45f, platform.transform.position.z - 1), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(jetpack, new Vector3(xPosition + powerUpPosition, background.transform.position.y + 5.45f, platform.transform.position.z - 1), Quaternion.identity);
                    break;
                default:
                    break;
            }
            Instantiate(platform, new Vector3(xPosition, background.transform.position.y + 5.2f, platform.transform.position.z), Quaternion.identity);
        }
    }
}
