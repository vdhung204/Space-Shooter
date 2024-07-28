using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public int speed;

    public void MoveBaseController(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
