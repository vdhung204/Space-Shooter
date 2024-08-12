using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Level_enemy : ScriptableObject
{
    public Enemy_Config[] levelEnemy;
    
    public Enemy_Config GetInforEnemyByLevel(int level)
    {
        if(level >= levelEnemy.Length) return levelEnemy[0];

        foreach(var lvl in levelEnemy)
        {
            if (lvl.level == level) return lvl;
        }
        return levelEnemy[0];
    }
}
[Serializable]
public struct Enemy_Config
{
    public int level;
    public int hp;
    public float speed;
}
