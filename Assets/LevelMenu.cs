using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < DataAccountPlayer.PlayerInfor.listLevelPlayer.Count; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenScene()
    {
        SceneManager.LoadScene(SceneName.GamePlay.ToString());
    }
}
