using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MoveBase
{
    public float hp;
    public GameObject bulelt;
    public Transform shootPos;
    public int damage;
    public int levelSpaceShip;
    public GameObject explosion;
    public virtual void Fire()
    {
        SmartPool.Instance.Spawn(bulelt, shootPos.position, shootPos.rotation);  
    }
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            OnSpaceShipDie();
        }
    }
    public void OnSpaceShipDie()
    {
        SmartPool.Instance.Despawn(gameObject);
        SmartPool.Instance.Spawn(explosion, transform.position, transform.rotation);
    }
}
