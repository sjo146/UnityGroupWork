using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalMusic : MonoBehaviour
{
    public AudioClip music;
    private AudioSource back;
    public GameObject globalMusic;
    GameObject MyMusic;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        MyMusic = GameObject.FindGameObjectWithTag("GlobalUIMusic");
        if (MyMusic == null)
        {
            MyMusic = (GameObject)Instantiate(globalMusic);
        }
        back = MyMusic.GetComponent<AudioSource>();
        back.loop = true; //设置循环播放  
        back.volume = 0.3f;//设置音量最大，区间在0-1之间
        back.clip = music;
        back.Play(); //播放背景音乐，
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        back.volume = slider.value;
    }
}
