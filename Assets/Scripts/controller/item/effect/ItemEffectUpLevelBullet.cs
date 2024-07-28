using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectUpLevelBullet : MonoBehaviour
{
    public void BulletPlayerUpLevel()
    {
        Debug.Log($"Dang chuan bi tang level");
        this.gameObject.GetComponent<PlayerController>().BulletPlayerUpLevel();
        
    }
}
