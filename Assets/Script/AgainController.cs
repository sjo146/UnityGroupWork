using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AgainController : MonoBehaviour
{
    public Button again;
    public Button over;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ssssssss");
        again.onClick.AddListener(playAgain);
        over.onClick.AddListener(palyOver);
        
    }

    public void playAgain()
    {
        SceneManager.LoadScene(1);
        Debug.Log("11111");
        
    }
    public void palyOver()
    {
        SceneManager.LoadScene(0);
        Debug.Log("22222");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
