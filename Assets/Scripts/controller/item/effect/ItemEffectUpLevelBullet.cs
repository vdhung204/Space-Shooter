using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectUpLevelBullet : MonoBehaviour
{
    public void BulletPlayerUpLevel()
    {
        this.gameObject.GetComponent<PlayerController>().BulletPlayerUpLevel();
        
    }
}
