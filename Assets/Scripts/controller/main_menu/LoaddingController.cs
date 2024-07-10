using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaddingController : MonoBehaviour
{
    public Button btnPlay;
    void Start()
    {
        btnPlay.onClick.AddListener(OnClickPlay);
    }

    private void OnClickPlay()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
