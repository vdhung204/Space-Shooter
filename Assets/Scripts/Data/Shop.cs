using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Shop : ScriptableObject
{
    public ShopInfor[] shopInfors;

}
[Serializable]
public struct ShopInfor
{
    public int id;
    public string image;
    public int price;
}
