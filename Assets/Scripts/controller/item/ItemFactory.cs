using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemFactory : SingletonMono<ItemFactory>
{
    public GameObject prefabItem;
    public ItemHP prefabItemHP;
    public ItemCoin prefabItemCoin;
    public ItemShield prefabItemShield;
    public ItemUpLevelBullet prefabItemUpLevelBullet;
    public static List<BaseItem> listItems = new List<BaseItem>();

    public static void CheckItem(Transform target)
    {
        foreach (BaseItem item in listItems)
        {
            if (Vector3.Distance(target.position, item.transform.position) < 2f)
            {
                item.setTarget(target);
                listItems.Remove(item);
                break;
            }
        }
    }



    public BaseItem Create(int index, Vector3 pos)
    {
        switch (index)
        {
            case 0:
                return CreatItemCoin(pos);
            case 1:
                return CreatItemCoin(pos);
            case 2:
                return CreatItemCoin(pos);
            case 3:
                return CreatItemCoin(pos);
            case 4:
                return CreatItemHp(pos);
            case 5:
                return CreatItemShield(pos);
            case 6: 
                return CreatItemUpLevelBullet(pos);
            case 7:
                return CreatItemCoin(pos);
            case 8:
                return CreatItemCoin(pos);
            case 9:
                return CreatItemCoin(pos);

        }
        return null;
    }

    private ItemHP CreatItemHp(Vector3 pos)
    {
        ItemHP item = Instantiate(prefabItemHP, pos, prefabItemHP.transform.rotation);
        item.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        listItems.Add(item);
        return item;
    }

    private ItemCoin CreatItemCoin(Vector3 pos)
    {
        ItemCoin item = Instantiate(prefabItemCoin, pos, prefabItemCoin.transform.rotation);
        listItems.Add(item);
        return item;
    }
    private ItemShield CreatItemShield(Vector3 pos)
    {
        ItemShield item = Instantiate(prefabItemShield, pos, prefabItemShield.transform.rotation);
        listItems.Add(item);
        return item;
    }
    private ItemUpLevelBullet CreatItemUpLevelBullet(Vector3 pos)
    {
        ItemUpLevelBullet item = Instantiate(prefabItemUpLevelBullet, pos, prefabItemUpLevelBullet.transform.rotation);
        listItems.Add(item);
        return item;
    }

}
