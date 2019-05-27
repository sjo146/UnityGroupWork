using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicPre : MonoBehaviour
{
    private static GlobalMusicPre _instance;
    private void Awake()
    {
        _instance = this;
         DontDestroyOnLoad(this.gameObject);
    }
 
}
