using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpLevelBullet : BaseItem
{
    protected override void ItemEffect(GameObject target)
    {
        target.AddComponent<ItemEffectUpLevelBullet>().BulletPlayerUpLevel();

    }
}
