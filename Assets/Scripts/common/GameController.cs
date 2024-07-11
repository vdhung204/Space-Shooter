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
    [SerializeField] private GameObject shipPlayer;
    [SerializeField] private Text scoretxt;
    [SerializeField] private Image[] ships;
    public Sprite iconPausel;
    public Sprite iconPlay;
    public Image iconPauseButton;
    public GameObject popupPause;
    public GameObject popupGameover;
    public Button btnPause;
    public Button btnExit;
    public Button btnResume;
    public GameObject enemy;

    private bool _isGameover = false;
    
    // Start is called before the first frame update
    void Start()
    {
        btnPause.onClick.AddListener(OnClickBtnPause);
        btnExit.onClick.AddListener(OnClickBtnExit);
        btnResume.onClick.AddListener(OnClickBtnResume);
        this.RegisterListener(EventID.PlayerDie, (sender, param) =>SpawnPlayer());
        this.RegisterListener(EventID.PlayerUpScore, (sender, param) => ShowScorePlayer());
        this.RegisterListener(EventID.GameOver, (sender, param) => Gameover());
        StartCoroutine(EnemySpawn());
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
    private void SpawnPlayer()
    {
        if (!_isGameover)
        {
            PlayerLiveImg();
            var posPlayer = new Vector3(0f, -4.8f, 0f);
            var ship = SmartPool.Instance.Spawn(shipPlayer, posPlayer, Quaternion.identity);
            ship.transform.localScale = new Vector3(3.3f, 3.3f, 3.3f);
        }
    }
    IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 5f));
        var pos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));
        var minX = -pos.x;
        var maxX =   pos.x;
        var maxY = pos.y + 1;
        var temp = UnityEngine.Random.Range(minX, maxX);

        var posEnemy = new Vector3(temp,maxY,0f);
        var go = SmartPool.Instance.Spawn(enemy, posEnemy, Quaternion.identity);
        go.transform.localScale = new Vector3(2f, 2f, 2f);
        StartCoroutine(EnemySpawn());   
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
            if (i < PlayerController.Instance.live)
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
        BackToMainMenu();
    }
    private void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
        Time.timeScale = 1;
    }
    private void OnClickBtnResume()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);

        Time.timeScale = 1;
        iconPauseButton.sprite = iconPausel;
        popupPause.SetActive(false);
    }
    private void Gameover()
    {
        
            popupGameover.SetActive(true);
            Time.timeScale = 0;
            _isGameover = true;
            BackToMainMenu();
        
    }
}
