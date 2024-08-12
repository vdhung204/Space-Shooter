using Core.Pool;
using Sound;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : SpaceShip
{
    private float timeShoot;
    private float TIMESHOT = 3f;
    public GameObject popupDamage;
    public TMP_Text tmp_Text;
    // Start is called before the first frame update
    void Start()
    {
        timeShoot = TIMESHOT;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeShoot -= Time.deltaTime;
        MoveBaseController(-transform.up);
        Fire();
        CheckLimitPosEnemy();

    }
    
    public override void Fire()
    {
        if (timeShoot <= 0)
        {
            base.Fire();
            SoundService.Instance.PlaySound(SoundType.sound_enemy_fire);
            timeShoot = TIMESHOT;
        }
    }
    private void CheckLimitPosEnemy()
    {
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        var minY = -pos.y -1;

        if (transform.position.y < minY)
        {
            SmartPool.Instance.Despawn(gameObject);
        }

    }
    public override void SpaceShipDie()
    {
        base.SpaceShipDie();
        var x = Random.Range(0, 15);
        ItemFactory.Instance.Create(x,this.transform.position);
        SoundService.Instance.PlaySound(SoundType.sound_enemy_die);

    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        tmp_Text.text = damage.ToString();
         SmartPool.Instance.Spawn(popupDamage, transform.position, Quaternion.identity);


        if (hp <= 0)
        {
            SpaceShipDie();
            this.PostEvent(EventID.EnemyDie);
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
        
    }
}
