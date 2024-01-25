using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    //Unityちゃんのオブジェクト
    private GameObject unitychan;


    // Start is called before the first frame update
    void Start()
    {
        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //自分のＺ座標
        //this.transform.position.z;
        //ユニティのＺ座標
        //this.unitychan.transform.position.z;

        float distance = this.unitychan.transform.position.z - this.transform.position.z;

        //Debug.Log("ユニティちゃんとの相対座標: " + distance);


        //ditanceが6より大きくなったら破棄

        if (distance > 6 )
        {
            
            Destroy(this.gameObject);
        }

       
    }
}
