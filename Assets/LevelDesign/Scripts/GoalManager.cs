using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalManager : MonoBehaviour
{
    public GameObject player;    //プレイヤーを格納するための変数
    public GameObject text;    　//テキストを格納するための変数
    private bool isGoal = false;    //Goalしたかどうか判定する

    void Update()
    {
        //Goalした後で画面をクリックされたとき
        if (isGoal && Input.GetMouseButton(0))
        {
            Restart();
        }
    }

    //当たり判定関数
    private void OnTriggerEnter(Collider other)
    {
        //当たってきたオブジェクトの名前がプレイヤーの名前と同じとき
        if (other.name == player.name)
        {
            //テキストの内容を変更する
            text.GetComponent<Text>().text = "ゴール！";
            text.SetActive(true);            //テキストをオンにして非表示→表示にする
            isGoal = true;            //Goal判定をTrueにする
        }
    }

    //シーンを再読み込みする
    private void Restart()
    {
        Scene loadScene = SceneManager.GetActiveScene();        // 現在のScene名を取得する
        SceneManager.LoadScene(loadScene.name);        // Sceneの読み直し
    }
}