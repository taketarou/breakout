using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //SceneManager.LoadScene("Result");を動かすために必要

public class GameMaster : MonoBehaviour
{

    public int boxNum;//現在存在するボックスの数　今回の場合、40が代入される
    public float nowTime;//ゲームが開始してからの秒数

    // Use this for initialization
    void Start()
    {
        nowTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //nowTimeに今までに経過した時間を入れています．Time.deltaTimeでは前のフレームから経過した時間を取得できます．Update()は毎フレーム実行されるのでその経過時間を毎フレーム足すことで経過時間を取得することができます
        nowTime += Time.deltaTime;
        
        //もし今のボックス数が0以下ならGameOver関数を呼び出し、Resultシーンに移動する。
        if (boxNum <= 0)
        {
            GameOver(nowTime.ToString("F0")+"秒でクリアできた!",true); //nowTime.ToString("F0")＝nowTimeを小数点第0位まで(＝小数点以下なし)の文字列に変換する
        }
    }

    public void GameOver(string resultMessage,bool isClear)
    {
        DataSender.resultMessage = resultMessage;
        DataSender.isClear = isClear;

        //Resultという名前の”シーン”に移動しろ．という命令
        SceneManager.LoadScene("Result");
    }
}