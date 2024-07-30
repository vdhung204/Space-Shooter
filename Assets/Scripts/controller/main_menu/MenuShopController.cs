using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuShopController : MonoBehaviour
{
    public Button btnStage;
    public Button btnBattle;
    public Button btnShop;
    public Button btnUse;
    public Button btnNextLeft;
    public Button btnNextRight;
    public Image space;
    public Sprite[] spaceShip;
    private int countSpaceShip = 0;

    private void Start()
    {
        //countSpaceShip = spaceShip.Length;

        btnStage.onClick.AddListener(OnClickBtnStage);
        btnBattle.onClick.AddListener(OnClickBtnBattle);
        btnShop.onClick.AddListener(OnClickBtnShop);
        btnUse.onClick.AddListener(OnClickBtnUse);
        btnNextLeft.onClick.AddListener(OnClickBtnNextLeft);
        btnNextRight.onClick.AddListener(OnClickBtnNextRight);
            }
    private void OnClickBtnStage()
    {
        Debug.Log($"da quay ve main menu");
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }private void OnClickBtnBattle()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.GamePlay.ToString());
    }private void OnClickBtnShop()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.MenuShop.ToString());
    }
    private void OnClickBtnUse()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        //SceneManager.LoadScene(SceneName.MenuShop.ToString());
        Debug.Log($"used !!");
    }
    private void OnClickBtnNextLeft()
   {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        /*if (CheckBtnNextIsOn())
        {*/
            if (countSpaceShip > 0)
            {
                countSpaceShip--;
                space.sprite = spaceShip[countSpaceShip];
            }
        //}
    }
    private void OnClickBtnNextRight()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        /*if (CheckBtnNextIsOn())
        {*/
            if (countSpaceShip < (spaceShip.Length - 1))
            {
                countSpaceShip++;
                space.sprite = spaceShip[countSpaceShip];
            }
        //}
    }
    /*private bool CheckBtnNextIsOn()
    {
        if ((space.sprite == spaceShip[0]) || (space.sprite == spaceShip[spaceShip.Length - 1]))
        {
            return false;
        }
        else
        {
            return true;
        }
    }*/
}
