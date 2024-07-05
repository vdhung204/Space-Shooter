using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBangController : MonoBehaviour
{
    private void DestroyMe()
    {
        SmartPool.Instance.Despawn(gameObject);
    }
}
