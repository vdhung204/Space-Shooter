using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpaceShip
{
    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        //this.RegisterListener(EventID.WasHitBulelt, (sender, param) => TakeDamage((int) param));


    }
    void Update()
    {
        MovePlayer();
        Fire();
    }
    /*public void MoveController()
    {
       
        Vector3 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction.z = 0;
         var newPos = Vector3.Lerp(transform.position, direction,speed);
        transform.position = newPos;

    }*/
    public void MovePlayer()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");
        

        Vector3 direction = new Vector3(x, y, 0);
        MoveBaseController(direction);

    }
    public override void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            base.Fire();
        }
    }
    private void SetDamage(int damage)
    {
        this.damage += damage;
    }
  
}   
