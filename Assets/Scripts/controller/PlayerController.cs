using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpaceShip
{
    [SerializeField] public int score = 0;
    [SerializeField] public int live = 3;
    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        this.RegisterListener(EventID.EnemyDie, (sender, param) => PlayerUpScore());


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
    private void PlayerUpScore()
    {
        score++;
        this.PostEvent(EventID.PlayerUpScore);
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if(hp<= 0)
        {
            live--;
            SpaceShipDie();
            this.PostEvent(EventID.PlayerDie);
        }
    }
    /*private void SetDamage(int damage)
    {
        this.damage += damage;
    }*/
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "bullet_enemy")
        {
            var temp = col.gameObject.GetComponent<BulletController>();
            TakeDamage(temp.damage);
            temp.DestroyBullet();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemyShip")
        {
            live--;
            SpaceShipDie();
            var temp = col.gameObject.GetComponent<EnemyController>();
            temp.SpaceShipDie();
            this.PostEvent(EventID.PlayerDie);
        }
    }
}   
