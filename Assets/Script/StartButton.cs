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
    // Start is called before the first frame update
    void Start()
    {
        start_btn.onClick.AddListener(PlayGame);
        restart_btn.onClick.AddListener(RePlayGame);
        end_btn.onClick.AddListener(ExitGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void RePlayGame()
    {
        SceneManager.LoadScene(1);

        AvatarSys._instance.LoadGame();

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
