using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button btnBattle;
    public Button btnSetting;
    public Button btnExitSetting;
    public Button btnSound;
    public Button btnMusic;
    public Button btnHaptic;
    public Button btnMenuShop;
    public GameObject popupSetting;
    private bool isPopupOnClick;
    public Image iconSound;
    public Sprite iconSoundOn;
    public Sprite iconSoundOff;
    public Image iconMusic;
    public Sprite iconMusicOn;
    public Sprite iconMusicOff;
    public Image iconHaptic;
    public Sprite iconHapticOn;
    public Sprite iconHapticOff;
    public bool isPopupSound = true;
    public bool isPopupMusic = true;
    public bool isPopupHaptic = true;

    void Start()
    {
        btnBattle.onClick.AddListener(OnClickBattle);
        btnSetting.onClick.AddListener(OnClickSetting);
        btnExitSetting.onClick.AddListener(OnClickExitSetting);
        btnSound.onClick.AddListener(OnClickBtnSound);
        btnMusic.onClick.AddListener(OnClickBtnMusic);
        btnHaptic.onClick.AddListener(OnClickBtnHaptic);
        btnMenuShop.onClick.AddListener(OnClickMenuShop);
    }

    private void OnClickBattle()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.GamePlay.ToString());
    }  
    private void OnClickMenuShop()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.MenuShop.ToString());
    }  
    private void OnClickSetting()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        popupSetting.SetActive(true);
        isPopupOnClick = true;
    }   
    private void OnClickExitSetting()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        popupSetting.SetActive(false);
        isPopupOnClick = false;
    }
    
        private void OnClickBtnSound()
    {
        if (isPopupOnClick)
        {
            Debug.Log($"nhan");
            //SoundService.Instance.PlaySound(SoundType.sound_click);
            if (isPopupSound)
            {
                Debug.Log($"tat");

                iconSound.sprite = iconSoundOff;
            }
            else
            {
                Debug.Log($"bat");
                iconSound.sprite = iconSoundOn;
            }
            
            isPopupSound = !isPopupSound;
            
        }
    }
    private void OnClickBtnMusic()
    {
        if (isPopupOnClick)
        {
            Debug.Log($"nhan");
            //SoundService.Instance.PlaySound(SoundType.sound_click);
            if (isPopupMusic)
            {
                Debug.Log($"tat");

                iconMusic.sprite = iconMusicOff;
            }
            else
            {
                Debug.Log($"bat");
                iconMusic.sprite = iconMusicOn;
            }

            isPopupMusic = !isPopupMusic;

        }
    }
    private void OnClickBtnHaptic()
    {
        if (isPopupOnClick)
        {
            Debug.Log($"nhan");
            //SoundService.Instance.PlaySound(SoundType.sound_click);
            if (isPopupHaptic)
            {
                Debug.Log($"tat");

                iconHaptic.sprite = iconHapticOff;
            }
            else
            {
                Debug.Log($"bat");
                iconHaptic.sprite = iconHapticOn;
            }

            isPopupHaptic = !isPopupHaptic;

        }
    }
    
}

public enum SceneName
{
    Loading,
    MainMenu,
    GamePlay,
    MenuShop,
}