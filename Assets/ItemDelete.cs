using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour
{
    //Unity�����̃I�u�W�F�N�g
    private GameObject unitychan;


    // Start is called before the first frame update
    void Start()
    {
        //Unity�����̃I�u�W�F�N�g���擾
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        //�����̂y���W
        //this.transform.position.z;
        //���j�e�B�̂y���W
        //this.unitychan.transform.position.z;

        float distance = this.unitychan.transform.position.z - this.transform.position.z;

        //Debug.Log("���j�e�B�����Ƃ̑��΍��W: " + distance);


        //ditance��6���傫���Ȃ�����j��

        if (distance > 6 )
        {
            
            Destroy(this.gameObject);
        }

       
    }
}
