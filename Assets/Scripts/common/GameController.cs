
using Core.Pool;
using Sound;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] shipPlayer;
    [SerializeField] private Text scoretxt;
    [SerializeField] private Image[] ships;
    public Sprite iconPausel;
    public Sprite iconPlay;
    public Image iconPauseButton;
    public GameObject popupPause;
    public GameObject popupEndGame;
    public Button btnPause;
    public Button btnExit;
    public Button btnResume;
    public GameObject enemy;

    //private static bool _isGameover = false;

    public int wave = 1;
    public int timeSpawn;
    public int countEnemy;
    public int countEnemyWave = 0;
    private WaveEnemy waveSpawn;

    private int currentWave = 1;

    private void Awake()
    {
        waveSpawn = Resources.Load<WaveEnemy>("data_csv/WaveEnemy");
    }

    // Start is called before the first frame update
    void Start()
    {
        btnPause.onClick.AddListener(OnClickBtnPause);
        btnExit.onClick.AddListener(OnClickBtnExit);
        btnResume.onClick.AddListener(OnClickBtnResume);
        this.RegisterListener(EventID.PlayerDie, (sender, param) =>SpawnPlayer());
        this.RegisterListener(EventID.PlayerUpScore, (sender, param) => ShowScorePlayer());
        this.RegisterListener(EventID.GameOver, (sender, param) => EndGame());
        this.RegisterListener(EventID.AddHP, (sender, param) => PlayerLiveImg());
        

        CheckToSpawnWave();
        SpawnPlayer();
        ShowScorePlayer();
        PlayerLiveImg();
       
    }
    
   
    public void OnEnable()
    {
        SoundService.Instance.PlayBackgroundMusic(SoundType.sound_bg);
    }

    private void OnClickBtnPause()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        Time.timeScale = 0;
        iconPauseButton.sprite = iconPlay;
        popupPause.SetActive(true);
    }
    private IEnumerator DelaySpawnPlayer()
    {
        yield return new WaitForSeconds(3f);

        //StartCoroutine(SpawnEnemy());
    }

    private void SpawnPlayer()
    {
        if (PlayerController.live > 0)
        {
            StartCoroutine(DelaySpawnPlayer());
            PlayerLiveImg();

            var playerShipIndex = DataAccountPlayer.PlayerInfor.shipPlayerUse;
            var shipUser = shipPlayer[0];

            switch (playerShipIndex)
            {
                case 1:
                    shipUser = shipPlayer[0];
                    break;
                case 2:
                    shipUser = shipPlayer[1];
                    break;
                default:
                    shipUser = shipPlayer[0];
                    break;

            } 

            var posPlayer = new Vector3(0f, -2.8f, 0f);
            SmartPool.Instance.Spawn(shipUser, posPlayer, Quaternion.identity);
            
        }
    }

    private void CheckToSpawnWave()
    {
        var waveEnemies = waveSpawn.waveEnemy;

        for (int i = 0; i < waveEnemies.Length; i++)
        {
            if (currentWave == waveEnemies[i].wave)
            {
                StartCoroutine (SpawnWave(waveEnemies[i].delay_time));

                return;
            }

        }
    }


    private IEnumerator SpawnWave(int delayTime)
    {
        yield return new WaitForSeconds(delayTime);

        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.5f);
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        var minX = -pos.x;
        var maxX = pos.x;
        var maxY = pos.y + 1;
        var temp = UnityEngine.Random.Range(minX, maxX);

        var posEnemy = new Vector3(temp, maxY, 0f);
        var go = SmartPool.Instance.Spawn(enemy, posEnemy, Quaternion.identity);
        go.transform.localScale = new Vector3(2f, 2f, 2f);

        countEnemyWave++;
        countEnemy = waveSpawn.GetWaveInfor(currentWave).spawn_enemy;

        if (countEnemyWave == countEnemy)
        {
            currentWave++;

            if (currentWave == waveSpawn.waveEnemy.Length)
            {
                EndGame();
                this.PostEvent(EventID.Victory);
            }
            else
            {
                CheckToSpawnWave();
                countEnemyWave = 0;
                 var timeDelay = waveSpawn.GetWaveInfor(currentWave).delay_time;
                this.PostEvent(EventID.WaveEnd, timeDelay);

            }
            
        }
        else
        {
            StartCoroutine(SpawnEnemy());
        }

    }

    private void ShowScorePlayer()
    {
        if (!PlayerController.Instance)
        {
            return;
        }
        scoretxt.text = $"{PlayerController.Instance.score}";
    }
    private void PlayerLiveImg()
    {
        if (!PlayerController.Instance)
        {
            return;
        }
        
        for (int i = 0; i < ships.Length; i++)
        {   
            if(PlayerController.live > ships.Length)
            {
                PlayerController.live = ships.Length;
            }
            if (i < PlayerController.live)
            {
                ships[i].enabled = true;
            }
            else
            {
                ships[i].enabled = false;
            }
        }
    }
    private void OnClickBtnExit()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        EndGame();
    }
    private void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
    private void OnClickBtnResume()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);

        Time.timeScale = 1;
        iconPauseButton.sprite = iconPausel;
        popupPause.SetActive(false);
    }
    private void EndGame()
    {
            popupEndGame.SetActive(true);
            Time.timeScale = 0;
        
    }
}
