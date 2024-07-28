using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveBase
{
    private float topLimit, bottomLimit;
    public int damage;
    public int levelBullet = 1;
    private BulletInfor bulletInfor;
    void Awake()
    {
        bulletInfor = Resources.Load<BulletInfor>("data_csv/BulletInfor");

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
        var lvlBullet = bulletInfor.GetLevelInforBuleltPlayer(2);
        SetInforBullet(lvlBullet);
    }
    public void BulletUpLevel()
    {
        Debug.Log($"Da tang level");
        this.levelBullet++;
        var lvl = bulletInfor.GetLevelInforBuleltPlayer(levelBullet);
        SetInforBullet(lvl);
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
