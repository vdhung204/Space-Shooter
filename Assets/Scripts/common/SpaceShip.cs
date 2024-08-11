using Core.Pool;
using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MoveBase
{
    public float hp;
    public GameObject bulelt;
    public Transform[] shootPos;
    public int levelSpaceShip;
    public GameObject explosion;
    public virtual void Fire()
    {
       
        for(int i = 0; i < shootPos.Length; i++)
        {
            var temp = SmartPool.Instance.Spawn(bulelt, shootPos[i].position, shootPos[i].rotation);
        if (temp.tag == "bullet_player")
                {
                    temp.GetComponent<BulletController>().InitInforBulelt();
                }
                temp.transform.localScale = new Vector3(1.1f,1.1f,1.1f);
        }
        
        
    }
    public virtual void TakeDamage(int damage)
    {
        hp -= damage;
       
    }
    public virtual void SpaceShipDie()
    {
        SmartPool.Instance.Despawn(gameObject);
        SmartPool.Instance.Spawn(explosion, transform.position, transform.rotation);
    }
}
