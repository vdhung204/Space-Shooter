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
        btnBattle.onClick.AddListener(OnClickBattle);
        btnSetting.onClick.AddListener(OnClickSetting);
        
        btnStage.onClick.AddListener(OnClickMainMenu);
        btnShop.onClick.AddListener(OnClickMenuShop);
        txtCoin.text = $"{DataAccountPlayer.PlayerInfor.coinPlayer}";
        txtExp.text = $"{DataAccountPlayer.PlayerInfor.expPlayer}";
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
   
}

public enum SceneName
{
    Loading,
    MainMenu,
    GamePlay,
    MenuShop,
}