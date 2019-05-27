using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLoading : MonoBehaviour
{
    public GameObject globalLoading;
    GameObject MyGlobalLoading;
    // Start is called before the first frame update
    void Start()
    {
        MyGlobalLoading = GameObject.FindGameObjectWithTag("GlobalLoadingPre");
        if (MyGlobalLoading == null)
        {
            MyGlobalLoading = (GameObject)Instantiate(globalLoading);
        }
        MyGlobalLoading.SetActive(false);
    }

    // Update is called once per frame
    public void ShowLoading()
    {
        MyGlobalLoading.SetActive(true);
    }
}
