using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopupEndGameController : MonoBehaviour
{
    public Text txtCoins;
    public Text txtExp;
    public Text txtEndGame;
    public Button btnBackToMenu;
    private bool _isEndGame = false;
    void Start()
    {
        this.RegisterListener(EventID.GameOver, (sender, param) => EndGame());
        //this.RegisterListener(EventID.Victory, (sender, param) => GameVictory());
        txtCoins.text = $"{PlayerController.Instance.coins}";
        txtExp.text = $"{PlayerController.Instance.score}";
        
        
        btnBackToMenu.onClick.AddListener(OnClickBtnBackToMenu);
    }
    private void Update()
    {
        if (!_isEndGame)
        {
            txtEndGame.text = $"GameOver";
        }
        else
        {
            txtEndGame.text = $"Victory";
        }

        }
    private void OnClickBtnBackToMenu()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
    private void EndGame()
    {
        _isEndGame = true;
    }
    
}
