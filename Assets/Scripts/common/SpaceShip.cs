using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MoveBase
{
    public float hp;
    public GameObject bulelt;
    public Transform shootPos;/*
    public int damage;*/
    public int levelSpaceShip;
    public GameObject explosion;
    public virtual void Fire()
    {
        var temp = SmartPool.Instance.Spawn(bulelt, shootPos.position, shootPos.rotation);  
        temp.transform.localScale = new Vector3(1.6f,1.6f,1.6f);
    }
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
       
    }
    public void SpaceShipDie()
    {
        SmartPool.Instance.Despawn(gameObject);
        SmartPool.Instance.Spawn(explosion, transform.position, transform.rotation);
    }
}
