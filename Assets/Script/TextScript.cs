using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text DisplayBtnText;                  //显示文本组件

    void Start()
    {
        int result = setScore(AvatarSys._instance.Score);
        Text text = this.gameObject.GetComponentInChildren<Text>();
        DisplayBtnText.text = " " + result;
    }
    int setScore(int Score)
    {
        if (Score < 20)
        {
            Score = 70;
        }
        else if (Score < 40)
        {
            Score = 80;
        }
        else if (Score < 50)
        {
            Score = 85;
        }
        else if (Score < 60)
        {
            Score = 90;
        }
        else Score = 100;
        return Score;
    }
}
