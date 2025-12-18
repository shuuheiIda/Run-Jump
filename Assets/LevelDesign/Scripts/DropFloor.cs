using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFloor : MonoBehaviour
{
    public GameObject dropFloor;    //床取得用
    public float dropWait = 0.5f;   //床落下待ち時間

    private void Update()
    {
        //落下後一定以下に下がったら
        if (dropFloor.transform.position.y < -5)
        {
            dropFloor.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);  //元の位置へ戻す
            dropFloor.GetComponent<Rigidbody>().useGravity = false;  //重力を戻す
            dropFloor.GetComponent<Rigidbody>().isKinematic = true;   //リジッドボディを戻す
        }
    }

    //コリジョンにプレイヤーが当たったら
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("useGrav", dropWait);   //床落下待ち時間適用後リジッドボディを使用可能に
            dropFloor.GetComponent<Rigidbody>().useGravity = true;  //重力をオン
        }
    }

    void useGrav()
    {
        dropFloor.GetComponent<Rigidbody>().isKinematic = false;   //リジッドボディを使用可能に
    }
}
