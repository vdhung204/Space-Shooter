using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveBase
{
    private float topLimit, bottomLimit;
    public int damage;
    public int levelBullet;
 
    void Awake()
    {
        

    }
    private void Start()
    {
        Vector3 moveLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        
        topLimit = moveLimit.y;
        bottomLimit = -moveLimit.y;
    }
    private void Update()
    {
        
        if(transform.position.y >= topLimit)
        {
            DestroyBullet();
        }else
        {
            MoveBaseController(transform.up);
        }
        
        if (transform.position.y <= bottomLimit)
        {
            DestroyBullet();
        }
        else
        {
            MoveBaseController(transform.up);
        }

    }
    public void InitInforBulelt()
    {
        var lvlBullet = GetLevelInforBuleltPlayer(PlayerController.bulletLevel);
        SetInforBullet(lvlBullet);
    }
   

    public LevelBullet GetLevelInforBuleltPlayer(int level)
    {
        var bulletInfor = Resources.Load<BulletInfor>("data_csv/BulletInfor");

        if (level > bulletInfor.levelBullets[bulletInfor.levelBullets.Length - 1].level)
        {
            return bulletInfor.levelBullets[bulletInfor.levelBullets.Length - 1];
        }

        foreach (LevelBullet lvl in bulletInfor.levelBullets)
        {
            if (lvl.level == level)
                return lvl;
        }

        return bulletInfor.levelBullets[0];
    }
    public void DestroyBullet()
    {
        SmartPool.Instance.Despawn(gameObject);
    }
    public void SetInforBullet(LevelBullet lvlBullet)
    {
        this.levelBullet = lvlBullet.level;
        this.damage = lvlBullet.damage;
        this.speed = lvlBullet.speed;
    }
}
