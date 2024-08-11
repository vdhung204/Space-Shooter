using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupDamage : MonoBehaviour
{
    public GameObject popupDamage;
    public TMP_Text popUpText;
    
    public void ShowTakeDamage(int damage, Transform trans)
    {
        popUpText.text = damage.ToString();
        SmartPool.Instance.Spawn(popupDamage,trans.position, Quaternion.identity);
    }
}
