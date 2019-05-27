using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseMusic : MonoBehaviour
{
    public Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        Dropdown.OptionData music1 = new Dropdown.OptionData();
        music1.text = "双星物语";
        Dropdown.OptionData music2 = new Dropdown.OptionData();
        music2.text = "现在放下那把剑";
        Dropdown.OptionData music3 = new Dropdown.OptionData();
        music3.text = "Flower dance";
        Dropdown.OptionData music4 = new Dropdown.OptionData();
        music4.text = "风居住的街道";
        Dropdown.OptionData music5 = new Dropdown.OptionData();
        music5.text = "Luv Letter";
        Dropdown.OptionData music6 = new Dropdown.OptionData();
        music6.text = "遥远岁月的回忆";
        dropdown.GetComponent<Dropdown>();
        dropdown.options.Add(music1);
        dropdown.options.Add(music2);
        dropdown.options.Add(music3);
        dropdown.options.Add(music4);
        dropdown.options.Add(music5);
        dropdown.options.Add(music6);

    }
    public void SelectMusic()
    {
        Debug.Log(transform.GetComponent<Dropdown>().value);
        GlobalMusic._instance.changeMusic(transform.GetComponent<Dropdown>().value);
    }

}
