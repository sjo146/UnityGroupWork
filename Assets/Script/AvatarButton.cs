using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AvatarButton : MonoBehaviour
{
    
    public void OnValueChanged(bool isOn)
    {
        if (isOn)
        {
            if (gameObject.name == "boy" || gameObject.name == "girl")
            {
                print(gameObject.name);
                AvatarSys._instance.SexChange();
                return;
            }
            string[] name = gameObject.name.Split('-');
            AvatarSys._instance.OnChangePeople(name[0], name[1]);
            switch (name[0])
            {
                case "pants":
                    PlayAnimation("item_pants");
                    break;
                case "shoes":
                    PlayAnimation("item_boots");
                    break;
                case "top":
                    PlayAnimation("item_shirt");
                    break;
                default:
                    break;
            }
        }
    }
    public void PlayAnimation(string animName)//换装动画名称
    {
        Animation anim = GameObject.FindWithTag("Player").GetComponent<Animation>();
        if (!anim.IsPlaying(animName)){
            anim.Play(animName);
            anim.PlayQueued("idle1");
        }
    }
    public void loadScenes()
    {
        SceneManager.LoadScene(2);//1是index
    }

}
