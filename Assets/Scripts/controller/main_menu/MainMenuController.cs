using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button btnBattle;
    public Button btnStage;
    public Button btnShop;
    public Button btnSetting;
    
    public GameObject popupSetting;
    public GameObject popupShop;
    
    public Text txtCoin;
    public Text txtExp;
    public Text txtLevelAcc;

    void Start()
    {
        this.RegisterListener(EventID.UpdateCoins, (sender, param)=> UpdateCoins() );
        btnBattle.onClick.AddListener(OnClickBattle);
        btnSetting.onClick.AddListener(OnClickSetting);
        
        btnStage.onClick.AddListener(OnClickMainMenu);
        btnShop.onClick.AddListener(OnClickMenuShop);
        txtCoin.text = $"{DataAccountPlayer.PlayerInfor.coinPlayer}";
        txtExp.text = $"{DataAccountPlayer.PlayerInfor.expPlayer}";
        Time.timeScale = 1f ;
    }

    private void OnEnable()
    {
        SoundService.Instance.PlayBackgroundMusic(SoundType.background_mainmenu);
    }

    private void OnClickBattle()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.GamePlay.ToString());
    }  
    private void OnClickMenuShop()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        popupShop.SetActive(true);
    } private void OnClickMainMenu()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }  
    private void OnClickSetting()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        popupSetting.SetActive(true);
    }   
    private void UpdateCoins()
    {
        txtCoin.text = $"{DataAccountPlayer.PlayerInfor.coinPlayer}";
    }   
   
}

public enum SceneName
{
    Loading,
    MainMenu,
    GamePlay,
    MenuShop,
}