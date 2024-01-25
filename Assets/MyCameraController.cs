using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    //unityちゃんのオブジェクト
    private GameObject unitychan;
    //unityちゃんとカメラの距離
    private float differnece;
    //Startis called before the first frame update

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        //unityちゃんとカメラのイチ（ｚ座標）の差を求める
        this.differnece = unitychan.transform.position.z - this.transform.position.z;


    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - differnece);
    }
}
