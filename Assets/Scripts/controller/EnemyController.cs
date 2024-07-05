using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : SpaceShip
{
    private float timeShoot;
    private float TIMESHOT = 3f;

    
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
    }
    public void MoveEnemyController()
    {
        var mainPos = PlayerController.Instance.transform.position;

        var newPos = new Vector3(mainPos.x - transform.position.x ,mainPos.y - transform.position.y ,0f);

        if (!CheckPosPlayerWithEnemy(mainPos))
        {
            MoveBaseController(newPos);

        }
        else 
        {
            if(timeShoot <= 0.2)
            {
                Fire();
                timeShoot = TIMESHOT;
            }
              
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

    
}
