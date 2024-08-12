using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupDamage : MonoBehaviour
{
    public GameObject popupDamage;
    public TMP_Text popUpText;
    public float timeDestroy;

    private void Update()
    {
        timeDestroy -= Time.deltaTime;
        if(timeDestroy < 0)
        {
            SmartPool.Instance.Despawn(gameObject);
        }
    }

    public void ShowTakeDamage(int damage)
    {
        popUpText.text = damage.ToString();
        SmartPool.Instance.Spawn(popupDamage,transform.position, Quaternion.identity);
    }
}
