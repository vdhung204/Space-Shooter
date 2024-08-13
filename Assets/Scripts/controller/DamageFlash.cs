using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    public GameObject blink;

    public static DamageFlash instance;
    private void Awake()
    {
        instance = this;
    }
    public void OnDamageFlash()
    {
        Invoke("EnableBlink", 0f);
        Invoke("DisableBlink", 0.1f);
    }
    private void EnableBlink()
    {
        blink.SetActive(true);
    }
    private void DisableBlink()
    {
        blink.SetActive(false);
    }
}
