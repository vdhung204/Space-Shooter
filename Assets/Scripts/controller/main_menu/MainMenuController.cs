using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button btnBattle;
    void Start()
    {
        btnBattle.onClick.AddListener(OnClickBattle);
    }

    private void OnClickBattle()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.GamePlay.ToString());
    }    
}

public enum SceneName
{
    MainMenu,
    GamePlay,
}