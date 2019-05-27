using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalMusic : MonoBehaviour
{
    public static GlobalMusic _instance;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;
    public AudioClip music4;
    public AudioClip music5;
    public AudioClip music6;
    private AudioSource back;
    public GameObject globalMusic;
    GameObject MyMusic;
    public Slider slider;
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
    }
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
        back.clip = music1;
        back.Play(); //播放背景音乐，
        slider.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        back.volume = slider.value;
    }

    public void changeMusic(int i)
    {
        if (i == 0) back.clip = music1;
        else if(i==1) back.clip = music2;
        else if(i==2) back.clip = music3;
        else if (i == 3) back.clip = music4;
        else if (i == 4) back.clip = music5;
        else if (i == 5) back.clip = music6;
        back.Play();
        back.volume = slider.value;

    }
}
