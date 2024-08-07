using Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoaddingController : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        StartCoroutine(LoadSceneMain());
    }

    private void OnClickPlay()
    {
        //SoundService.Instance.PlaySound(SoundType.sound_click);
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
    IEnumerator LoadSceneMain()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(SceneName.MainMenu.ToString());

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            slider.value = progressValue;
            yield return null;
        }
    }
}
