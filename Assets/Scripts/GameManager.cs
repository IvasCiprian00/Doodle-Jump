using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Player playerScript;

    [SerializeField]
    private float height;
    private void Update()
    {
        height = player.transform.position.y;
        if(playerScript.isAscending && height > background.transform.position.y)
        {
            background.transform.position = new Vector3(background.transform.position.x, height, background.transform.position.z);
            cam.transform.position = new Vector3 (cam.transform.position.x, height, cam.transform.position.z);
        }
    }
}
