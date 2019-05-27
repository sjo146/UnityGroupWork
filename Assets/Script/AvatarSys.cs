using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AvatarSys : MonoBehaviour
{
    public static AvatarSys _instance;

    private Transform girlSourceTrans;
    private GameObject girlTarget;//骨架物体 换装的人
    private Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> girlData = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();
    //小女孩所有的资源信息 嵌套字典  //部位名字 部位编号
    Transform[] girlHips;//小女孩的骨骼
    private Dictionary<string, SkinnedMeshRenderer> girlSmr = new Dictionary<string, SkinnedMeshRenderer>();
    //女孩换装骨骼上面的smr信息
    private string[,] girlStr = new string[,] { { "eyes", "1" }, { "hair", "1" }, { "top", "1" }, { "pants", "1" }, { "shoes", "1" }, { "face", "1" } };
    //初始化信息

    private Transform boySourceTrans;
    private GameObject boyTarget;//骨架物体 换装的人
    private Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> boyData = new Dictionary<string, Dictionary<string, SkinnedMeshRenderer>>();
    //小女孩所有的资源信息 嵌套字典  //部位名字 部位编号
    Transform[] boyHips;//小女孩的骨骼
    private Dictionary<string, SkinnedMeshRenderer> boySmr = new Dictionary<string, SkinnedMeshRenderer>();
    //女孩换装骨骼上面的smr信息
    private string[,] boyStr = new string[,] { { "eyes", "1" }, { "hair", "1" }, { "top", "1" }, { "pants", "1" }, { "shoes", "1" }, { "face", "1" } };
    //初始化信息

    public int nowcount = 0; //0 是女孩 1 是男孩
    public GameObject girlPanal;
    public GameObject boyPanal;
    // private GameObject boy;
    // private GameObject girl;
    // public GameObject sexPanal;
    public Toggle boytoggle;
    public Toggle girltoggle;
    private int replay=2;

    public string[,] getGirlStr()
    {
        return this.girlStr;
    }
    public string[,] getBoyStr()
    {
        return this.boyStr;
    }

    void Awake()
    {
        Debug.Log("唤醒");
        _instance = this;
        DontDestroyOnLoad(this.gameObject);//不删除游戏物体
    }

    void Start()
    {
        // boy = GameObject.FindGameObjectWithTag("boy");
        // girl = GameObject.FindGameObjectWithTag("girl");
        Debug.Log("开始");
        readReplay();
        if(replay == 1)
        {
            LoadGame();
            if(this.nowcount == 1)
            {
                GirlAvatar();
                BoyAvatar();
                boyTarget.AddComponent<SpinWithMouse>();
                girlTarget.AddComponent<SpinWithMouse>();
                boyTarget.SetActive(true);
                girlTarget.SetActive(false); 
                nowcount = 0;
                boytoggle.isOn = true;
            }
            else
            {
                GirlAvatar();
                BoyAvatar();
                boyTarget.AddComponent<SpinWithMouse>();
                girlTarget.AddComponent<SpinWithMouse>();
                girlTarget.SetActive(true);
                boyTarget.SetActive(false); 
                girltoggle.isOn = true;
            }
        }
        else{
            GirlAvatar();
            BoyAvatar();
            boyTarget.AddComponent<SpinWithMouse>();
            girlTarget.AddComponent<SpinWithMouse>();
            boyTarget.SetActive(false); 
            girltoggle.isOn = true;
        }
        
        
        
        
    }

    public void GirlAvatar()
    {
        InstantiateGirl();
        SaveDate(girlSourceTrans, girlData, girlTarget, girlSmr);
        InitAvatarGirl();

    }
    public void BoyAvatar()
    {
        InstantiateBoy();
        SaveDate(boySourceTrans, boyData, boyTarget, boySmr);
        InitAvatarBoy();
        //boyTarget.SetActive(false);
    }

    void InstantiateGirl()
    {
        GameObject go = Instantiate(Resources.Load("FemaleModel")) as GameObject;//加载资源物体
        girlSourceTrans = go.transform;
        go.SetActive(false);//使得产生的所有资源不显示
        girlTarget = Instantiate(Resources.Load("FemaleTarget")) as GameObject;
        girlHips = girlTarget.GetComponentsInChildren<Transform>();
    }

    void InstantiateBoy()
    {
        GameObject go = Instantiate(Resources.Load("MaleModel")) as GameObject;//加载资源物体
        boySourceTrans = go.transform;
        go.SetActive(false);//使得产生的所有资源不显示
        boyTarget = Instantiate(Resources.Load("MaleTarget")) as GameObject;
        boyHips = boyTarget.GetComponentsInChildren<Transform>();
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))//0 是鼠标左键
        {
            int num = Random.Range(1, 7);
            // changeMesh("top", num.ToString());
        }
    }
    void SaveDate(Transform sourceTrans, Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> data, GameObject target, Dictionary<string, SkinnedMeshRenderer> smr)
    {
        data.Clear();//先清空
        smr.Clear();
        //安全校验
        if (sourceTrans == null)
            return;
        SkinnedMeshRenderer[] parts = sourceTrans.GetComponentsInChildren<SkinnedMeshRenderer>();//遍历所有子物体SkinnedMeshRenderer，进行存储
        foreach (var part in parts)
        {
            string[] names = part.name.Split('-');
            //查看是否第一次遍历
            if (!data.ContainsKey(names[0]))
            {
                //生成对应的部位且只生成一个
                GameObject partGo = new GameObject();
                partGo.name = names[0];
                partGo.transform.parent = target.transform;

                smr.Add(names[0], partGo.AddComponent<SkinnedMeshRenderer>());//把骨骼上的smr信息存储
                data.Add(names[0], new Dictionary<string, SkinnedMeshRenderer>());

            }
            data[names[0]].Add(names[1], part);
        }
    }
    void changeMesh(string part, string num, Dictionary<string, Dictionary<string, SkinnedMeshRenderer>> data, Transform[] hips, Dictionary<string, SkinnedMeshRenderer> smr,string [,] str)//传入部位和编号，拿去对应的smr
    {
        SkinnedMeshRenderer skm = data[part][num];//要更换的部位
        List<Transform> bones = new List<Transform>();
        foreach (var trans in skm.bones)
        {
            foreach (var bone in hips)
            {
                if (bone.name == trans.name)
                {
                    bones.Add(bone);
                    break;
                }
            }
        }
        //换装三步实现
        smr[part].bones = bones.ToArray();
        smr[part].materials = skm.materials;
        smr[part].sharedMesh = skm.sharedMesh;

        saveData(part, num, str);
    }

    void InitAvatarGirl()
    {
        //初始化部件，最好的办法是建立一个二维数组
        int length = girlStr.GetLength(0);//0 获得行数 1 获得列数
        for (int i = 0; i < length; i++)
        {
            changeMesh(girlStr[i, 0], girlStr[i, 1], girlData, girlHips, girlSmr,girlStr);//穿衣服
        }

    }
    void InitAvatarBoy()
    {
        //初始化部件，最好的办法是建立一个二维数组
        int length = boyStr.GetLength(0);//0 获得行数 1 获得列数
        for (int i = 0; i < length; i++)
        {
            changeMesh(boyStr[i, 0], boyStr[i, 1], boyData, boyHips, boySmr,boyStr);//穿衣服
        }

    }
    public void OnChangePeople(string part, string num)
    {
        if (nowcount == 0)
        {
            changeMesh(part, num, girlData, girlHips, girlSmr,girlStr);
        }
        else
        {
            changeMesh(part, num, boyData, boyHips, boySmr,boyStr);
        }
    }
    public void SexChange()
    {//性别改变，人物隐藏面板
        if (nowcount == 0)
        {
            nowcount = 1;
            Debug.Log(nowcount);
            boyTarget.SetActive(true);
            girlTarget.SetActive(false);
            boyPanal.SetActive(true);
            girlPanal.SetActive(false);
        }
        else
        {
            nowcount = 0;
            Debug.Log(nowcount);
            boyTarget.SetActive(false);
            girlTarget.SetActive(true);
            boyPanal.SetActive(false);
            girlPanal.SetActive(true);
        }

    }

    void saveData(string part, string number, string[,] str)
    {
        //初始化部件，最好的办法是建立一个二维数组
        int length = girlStr.GetLength(0);//0 获得行数 1 获得列数
        for (int i = 0; i < length; i++)
        {

            if (str[i, 0] == part)
            {

                str[i, 1] = number;
            }
        }
    }

    
    
    public void LoadGame(){ 

        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            this.nowcount = (int)save.avatar;
            if(this.nowcount == 0)
            {
                this.girlStr = save.str;
            }
            else
            {
                this.boyStr = save.str;
            }
            Debug.Log("Game Loaded");
            Debug.Log(save.avatar);
            Debug.Log(nowcount);

        }
        else
        {
            Debug.Log("No game saved!");
        }
        
    }

    public void readReplay()
    {
        if (File.Exists(Application.persistentDataPath + "/replayOrNot.save"))
        {
            
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/replayOrNot.save", FileMode.Open);
            this.replay = (int)bf.Deserialize(file);
            file.Close();

            Debug.Log("play replay:"+replay);

        }
        else
        {
            Debug.Log("play replay fail");
        }
    }
}
