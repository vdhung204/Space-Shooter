using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SpaceShip
{
    private float timeShoot;
    private float TIMESHOT = 2f;

    
    // Start is called before the first frame update
    void Start()
    {
        timeShoot = TIMESHOT;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeShoot -= Time.deltaTime;
        MoveEnemyController();
        Fire();
    }
    public void MoveEnemyController()
    {
        /*var mainPos = PlayerController.Instance.transform.position;

        var newPos = new Vector3(mainPos.x - transform.position.x ,mainPos.y - transform.position.y ,0f);
        
        if (!CheckPosPlayerWithEnemy(mainPos))
        {*/
            MoveBaseController( - transform.up);

        /*}
        else 
        {
            if(timeShoot <= 0.8)
            {
                Fire();
                timeShoot = TIMESHOT;
            }
              
        }*/
    }
    public override void Fire()
    {
        if (timeShoot <= 0.3)
        {
            base.Fire();
            timeShoot = TIMESHOT;
        }
    }
    public bool CheckPosPlayerWithEnemy(Vector3 direction)
    {
        var distanPos = Vector3.Distance(transform.position,direction);

        if (distanPos <= 5)
        {
            return true;
        }else
        { 
            return false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "bullet_player")
        {
            var temp = col.gameObject.GetComponent<BulletController>();
            TakeDamage(temp.damage);
            temp.DestroyBullet();
        }
        if (col.gameObject.tag == "move_limit")
        {
           SmartPool.Instance.Despawn(gameObject);
        }
    }
}
