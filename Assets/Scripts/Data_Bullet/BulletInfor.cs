using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class BulletInfor : ScriptableObject
{
    public LevelBullet[] levelBullets;

    public LevelBullet GetLevelInforBuleltPlayer(int level)
    {
        if (level > levelBullets[levelBullets.Length - 1].level)
        {
            return levelBullets[levelBullets.Length - 1];
        }
        foreach (LevelBullet lvl in levelBullets)
        {
            if (lvl.level == level)
                return lvl;
        }

        return levelBullets[0];
    }
}
[Serializable]
public struct LevelBullet
{
    public int level;
    public int damage;
    public int speed;
}
