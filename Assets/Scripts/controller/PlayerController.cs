using Core.Pool;
using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SpaceShip
{
    [SerializeField] public int score = 0;
    [SerializeField] public static int live = 3;
    private float timeshoot;
    private float TIMESHOOT = 1f;
    public int coins = 0;

    private BoxCollider2D box;
    public static int bulletLevel = 1;

    public static PlayerController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        this.RegisterListener(EventID.EnemyDie, (sender, param) => PlayerUpScore());
        box = GetComponent<BoxCollider2D>();

    }
    private void Start()
    {
        //StartCoroutine(PlayerFire());
        timeshoot = TIMESHOOT;
        Debug.Log(live);
    }
    void Update()
    {
        ItemFactory.CheckItem(this.transform);
        MovePlayer();
        timeshoot -= Time.deltaTime;
        Fire();
    }
    private void MovePlayer()
    {
        Vector3 direction = transform.position;
        if (Input.GetMouseButton(0))
        {
            direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        direction.z = 0;
        var newPos = Vector3.Lerp(transform.position, direction, speed);
        transform.position = newPos;

        var moveLimit = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));


        var minX = -moveLimit.x + 0.5f;
        var maxX = moveLimit.x - 0.5f;

        var minY = -moveLimit.y - 0.5f;
        var maxY = moveLimit.y - 1.7f;

        var mainPos = transform.position;

        if (mainPos.x < minX)
        {
            mainPos.x = minX;
        }
        else if (mainPos.x > maxX)
        {
            mainPos.x = maxX;
        }

        if (mainPos.y < minY)
        {
            mainPos.y = minY;
        } else if (mainPos.y > maxY)
        {
            mainPos.y = maxY;
        }

        transform.position = mainPos;
    }

    /*IEnumerator PlayerFire()
    {
        yield return new WaitForSeconds(0.5f);
        Fire();
        SoundService.Instance.PlaySound(SoundType.sound_fire_1);
        StartCoroutine(PlayerFire());
    }*/
    public override void Fire()
    {

        if (timeshoot <=0)
        {
            base.Fire();
            SoundService.Instance.PlaySound(SoundType.sound_fire_1);
            timeshoot = TIMESHOOT;
        }
    }
    private void PlayerUpScore()
    {
        score++;

        /*if (score > 0 && score % 10 == 0)
        {
            this.PostEvent(EventID.SkipBg);
        }*/

        DataAccountPlayer.PlayerInfor.expPlayer ++;
        DataAccountPlayer.SaveDataPlayerInfor();
        this.PostEvent(EventID.PlayerUpScore);
    }
    public void AddLive()
    {
        live++;
    }
    public void TakeCoin()
    {
        coins++;
        DataAccountPlayer.PlayerInfor.coinPlayer ++;
        DataAccountPlayer.SaveDataPlayerInfor();
    }
    public void BulletPlayerUpLevel()
    {
        bulletLevel ++;
        
    }
    public void Shield()
    {
        //box.gameObject.SetActive(false);
        Debug.Log($"Bat tu");
    }
    private IEnumerator BackToTakeDamage()
    {
        yield return new WaitForSeconds(5f);
        box.gameObject.SetActive(true);
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if(hp<= 0)
        {
            SpaceShipDie();
            
        }
    }
    public override void SpaceShipDie()
    {
        live--;
        base.SpaceShipDie();
        if (live == 0)
        {
            this.PostEvent(EventID.GameOver);
        }

        SoundService.Instance.PlaySound(SoundType.sound_player_die);
        this.PostEvent(EventID.PlayerDie);
        
    }
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
                    SpaceShipDie();
                    var temp = col.gameObject.GetComponent<EnemyController>();
                    temp.SpaceShipDie();
                }
    }
}   
