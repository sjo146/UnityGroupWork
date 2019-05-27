using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveGameButton : MonoBehaviour
{
    private Save CreateSaveGameObject(){
		Save save = new Save();
        save.avatar = AvatarSys._instance.nowcount;
        if(AvatarSys._instance.nowcount == 0){
            save.str = AvatarSys._instance.getGirlStr();
        }
        else{
            save.str = AvatarSys._instance.getBoyStr();
        }
        return save;
	}

    public void SaveGame(){
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved");
        Debug.Log(AvatarSys._instance.nowcount);
        Debug.Log(save.avatar);
    }

}
