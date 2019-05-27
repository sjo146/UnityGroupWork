using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button start_btn;
    public Button restart_btn;
    public Button end_btn;
    public Button setting_btn;
    public GameObject option;
    public GameObject setting;
    public Button back_btn;
    // Start is called before the first frame update
    void Start()
    {
        setting.SetActive(false);
        start_btn.onClick.AddListener(PlayGame);
        restart_btn.onClick.AddListener(RePlayGame);
        end_btn.onClick.AddListener(ExitGame);
        setting_btn.onClick.AddListener(Setting);
        back_btn.onClick.AddListener(Back);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Debug.Log("开始游戏");
    }
    public void RePlayGame()
    {
        SceneManager.LoadScene(1);

      

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Setting()
    {
        option.SetActive(false);
        setting.SetActive(true);

    }
    public void Back()
    {
        option.SetActive(true);
        setting.SetActive(false);
    }
}
