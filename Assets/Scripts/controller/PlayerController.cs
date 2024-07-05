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
        //this.RegisterListener(EventID.EnemyAttack, (sender, param) => TakeDamage((int) param));


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
    public override void TakeDamage(int damage)
    {
        /*this.damage += damage;*/
        base.TakeDamage(this.damage);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet_enemy")
        {
            Debug.LogError("player die");
        }
    }
}   
