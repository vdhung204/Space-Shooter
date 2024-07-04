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

    public virtual void Fire()
    {
        Instantiate(bulelt,shootPos.position,shootPos.rotation);    
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            OnSpaceShipDie();
        }
    }
    public void OnSpaceShipDie()
    {
        Destroy(gameObject);
    }
}
