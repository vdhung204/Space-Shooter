using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MoveBase
{
    private float topLimit, bottomLimit;
    public int damage;
    public int levelBullet;
    
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

    }
    public void SetBulletDamage(int damage)
    {
        this.damage = damage;
    }
    public void DestroyBullet()
    {
        //Destroy(gameObject);
        SmartPool.Instance.Despawn(gameObject);
        
    }
    public void SetInforBullet()
    {

    }
    /*private void OnCollisionEnter2D(Collision2D col)
    {
        var objTakeDame = col.gameObject.GetComponent<SpaceShip>();

        if (objTakeDame != null)
        {

            objTakeDame.TakeDamage(this.damage);
            DestroyBullet();
        } 
    }*/
}
