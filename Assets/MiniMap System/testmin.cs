using UnityEngine;
using System.Collections;

public class testmin : MonoBehaviour
{
    public Camera minicamera;
    public Transform player;
    public Transform miniplayerIcon;//小地图人物图标
    public Transform maxplayerIcon;
    private float mapSize;//小地图的orthographicSize大小
    public float Maxmapsize;//大地图的orthographicSize大小
    public float minSize;//小地图的orthographicSize最小值
    public float maxSize; //小地图的orthographicSize最大值
    public GameObject maxmap;//大地图
    public GameObject minimap;//小地图

    private bool flag;


    public bool isMaxmap = false;//是否打开大地图

    void Awake()
    {
        mapSize = minicamera.orthographicSize;

    }
    // Use this for initialization
    void Start()
    {
        maxmap.gameObject.SetActive(isMaxmap);
    }

    // Update is called once per frame
    void Update()
    {

        if (isMaxmap)
        {

            maxplayerIcon.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);//地图中的人物图标会根据3D物体的人物转动而转动
            minicamera.transform.position = new Vector3(player.position.x,
                       minicamera.transform.position.y, player.position.z);//移动
        }
        else
        {

            minicamera.transform.position = new Vector3(player.position.x, minicamera.transform.position.y, player.position.z);
            miniplayerIcon.eulerAngles = new Vector3(0, 0, -player.eulerAngles.y);
        }
        Mapswitch(isMaxmap);


    }



    void Mapswitch(bool flag)
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!flag)
            {
                OpenMaxmap();
            }
            else
            {
                OpenMinimap();
            }
        }

    }
    //打开大地图
    public void OpenMaxmap()
    {
        maxmap.gameObject.SetActive(true);
        minimap.gameObject.SetActive(false);
        minicamera.orthographicSize = Maxmapsize;
        isMaxmap = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    //打开小地图
    public void OpenMinimap()
    {
        maxmap.gameObject.SetActive(false);
        minimap.gameObject.SetActive(true);
        minicamera.orthographicSize = mapSize;
        isMaxmap = false;
        Cursor.visible = false;
    }

    //缩放地图方法
    public void ChangeMapSize(float value)
    {
        mapSize += value;
        mapSize = Mathf.Clamp(mapSize, minSize, maxSize);
        minicamera.orthographicSize = mapSize;
    }
}