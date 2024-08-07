using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sound;

public class PopupSettingController : MonoBehaviour
{
    private bool isPopupSound = true;
    private bool isPopupMusic = true;
    private bool isPopupHaptic = true;
    public GameObject popupSetting;
    public Image iconSound;
    public Sprite iconSoundOn;
    public Sprite iconSoundOff;
    public Image iconMusic;
    public Sprite iconMusicOn;
    public Sprite iconMusicOff;
    public Image iconHaptic;
    public Sprite iconHapticOn;
    public Sprite iconHapticOff;
    public Button btnSound;
    public Button btnMusic;
    public Button btnHaptic;
    public Button btnExitSetting;
    // Start is called before the first frame update
    
    void Start()
    {
        btnSound.onClick.AddListener(OnClickBtnSound);
        btnMusic.onClick.AddListener(OnClickBtnMusic);
        btnHaptic.onClick.AddListener(OnClickBtnHaptic);
        btnExitSetting.onClick.AddListener(OnClickExitSetting);
        IconSound();
        IconMusic();
        IconHaptic();
    }
    private void IconSound()
    {
        if (!DataAccountPlayer.PlayerSetting.soundOn)
        {
            iconSound.sprite = iconSoundOff;

        }else
         {
            Debug.Log($"bat");
            iconSound.sprite = iconSoundOn;
         }

    }
    private void IconMusic()
    {
        if (!DataAccountPlayer.PlayerSetting.musicOn)
        {
            iconMusic.sprite = iconMusicOff;

        }else
         {
            Debug.Log($"bat");
            iconMusic.sprite = iconMusicOn;
         }

    }
    private void IconHaptic()
    {
        if (!DataAccountPlayer.PlayerSetting.vibrationOn)
        {
            iconHaptic.sprite = iconHapticOff;

        }else
         {
            Debug.Log($"bat");
            iconHaptic.sprite = iconHapticOn;
         }

    }
    private void OnClickBtnSound()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        isPopupSound = DataAccountPlayer.PlayerSetting.soundOn;
        DataAccountPlayer.PlayerSetting.soundOn= !isPopupSound;
        DataAccountPlayer.SaveDataPlayerSetting();
        IconSound();    
    }
    private void OnClickBtnMusic()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        isPopupMusic = DataAccountPlayer.PlayerSetting.musicOn;
        DataAccountPlayer.PlayerSetting.musicOn = !isPopupMusic;
        DataAccountPlayer.SaveDataPlayerSetting();
        IconMusic();


    }
    private void OnClickBtnHaptic()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        isPopupHaptic = DataAccountPlayer.PlayerSetting.vibrationOn;
        DataAccountPlayer.PlayerSetting.vibrationOn = !isPopupHaptic;
        DataAccountPlayer.SaveDataPlayerSetting();
        IconHaptic();
    }
    private void OnClickExitSetting()
    {
        SoundService.Instance.PlaySound(SoundType.sound_click);
        popupSetting.SetActive(false);
        
    }
}
