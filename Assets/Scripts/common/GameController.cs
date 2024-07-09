using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject shipPlayer;
    [SerializeField] private Text scoretxt;
    [SerializeField] private Image[] ships;

    // Start is called before the first frame update
    void Start()
    {
        this.RegisterListener(EventID.PlayerDie, (sender, param) =>SpawnPlayer());
        this.RegisterListener(EventID.PlayerUpScore, (sender, param) => ShowScorePlayer());

        SpawnPlayer();
        ShowScorePlayer();
        PlayerLiveImg();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlayer()
    {
        PlayerLiveImg();
        var posPlayer = new Vector3(0f, -4.8f,0f);
        var ship = SmartPool.Instance.Spawn(shipPlayer, posPlayer, Quaternion.identity);
        ship.transform.localScale = new Vector3(4.8f,4.8f,4.8f);
    }
    private void ShowScorePlayer()
    {
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
}
