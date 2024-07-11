using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemFactory : SingletonMono<ItemFactory>
{
    public GameObject prefabItem;
    public ItemHP prefabItemHP;
    //public ItemSpeed prefabItemSpeed;

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
                return CreatItemHp(pos);
           /* case 1:
                return CreatItemSpeed(pos);
                *//*case 2:
                    return createItem<ItemSpeed>(pos);
                case 3:
                    return createItem<ItemPower>(pos);*/
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

    /*private ItemSpeed CreatItemSpeed(Vector3 pos)
    {
        ItemSpeed item = Instantiate(prefabItemSpeed, pos, prefabItemSpeed.transform.rotation);
        listItems.Add(item);
        return item;
    }*/

}
