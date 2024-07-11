using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectCoin : MonoBehaviour
{
    public void TakeCoin()
    {
        Debug.Log(PlayerController.Instance.coins);
       
        this.gameObject.GetComponent<PlayerController>().TakeCoin(); 
        Debug.Log(PlayerController.Instance.coins);
    }
}
