using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public Text timeText;    //時間表示用テキスト
    public float limit = 30.0f;    //制限時間
    public GameObject text;    //ゲームオーバー表示用テキスト
    public GameObject player;    //プレイヤー格納用
    private bool isGameOver = false;    //ゲームオーバー判定

    void Start()
    {
        timeText.text = "Time:" + limit + "秒";
    }

    void Update()
    {
        //ゲームオーバー状態で画面がクリックされたとき
        if (isGameOver && Input.GetMouseButton(0))
        {
            Restart();
        }

        //時間制限がきたとき
        if (limit < 0)
        {
            //ゲームオーバーを表示する
            text.GetComponent<Text>().text = "GameOver...";
            text.SetActive(true);
            isGameOver = true;            //ゲームオーバー
            return;
        }

        //時間をカウントダウンする
        limit -= Time.deltaTime;
        timeText.text = "Time:" + limit.ToString("f1") + "秒";
    }

    //シーンを再読み込みする
    private void Restart()
    {
        // 現在のScene名を取得する
        Scene loadScene = SceneManager.GetActiveScene();
        // Sceneの読み直し
        SceneManager.LoadScene(loadScene.name);
    }
}