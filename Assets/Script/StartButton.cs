using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StartButton : MonoBehaviour
{
    public Button start_btn;
    public Button restart_btn;
    public Button end_btn;
    public Button setting_btn;
    public GameObject option;
    public GameObject setting;
    public Button back_btn;

    private int replay=0;
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
        PlayAndReplay(0);
        SceneManager.LoadScene(1);
        Debug.Log("开始游戏");
    }
    public void RePlayGame()
    {
        PlayAndReplay(1);
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

    public void PlayAndReplay(int replay)
    {
        this.replay = replay;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/replayOrNot.save");
        bf.Serialize(file, replay);
        file.Close();

        Debug.Log("play replay:"+replay);
    }
}
