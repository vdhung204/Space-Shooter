using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class BulletInfor : ScriptableObject
{
    public LevelBullet[] levelBullets;

}
[Serializable]
public struct LevelBullet
{
    public int level;
    public int damage;
    public int speed;
}
