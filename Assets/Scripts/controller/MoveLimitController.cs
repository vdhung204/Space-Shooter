using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLimitController : MonoBehaviour
{ 
    public float minX, minY, maxX, maxY;
    private void Start()
    {
        var moveLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));


        minX = - moveLimit.x + 0.5f ;
        maxX = moveLimit.x -0.5f;

        minY = - moveLimit.y - 0.5f;
        maxY = moveLimit.y - 1.7f;
    }
    private void Update()
    {
        var mainPos = transform.position;

        if (mainPos.x < minX)
        {
            mainPos.x = minX;
        }
        else if (mainPos.x > maxX)
        {
            mainPos.x = maxX;
        }

        if (mainPos.y < minY)
        {
            mainPos.y = minY;
        } else if (mainPos.y > maxY)
        {
            mainPos.y = maxY;
        }

        transform.position = mainPos;
    }
}
