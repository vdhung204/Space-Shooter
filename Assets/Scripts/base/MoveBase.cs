using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBase : MonoBehaviour
{
    public float speed;

    public void MoveBaseController(Vector3 direction)
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
