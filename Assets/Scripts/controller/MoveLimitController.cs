using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLimitController : MonoBehaviour
{
    private float minX,minY, maxX, maxY;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 moveLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        minX = - moveLimit.x; 
        minY = - moveLimit.y; 
        maxX = moveLimit.x;
        maxY = moveLimit.y;
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = transform.position;
        if (playerPos.x < minX)
        {
             playerPos.x = minX;
        }
        else if (playerPos.x > maxX)
        {
            playerPos.x = maxX;
        }

        if (playerPos.y < minY)
        {
            playerPos.y = minY;
        }
        else if (playerPos.y > maxY)
        {
            playerPos.y = maxY;
        }

        transform.position = playerPos;
    }
}
