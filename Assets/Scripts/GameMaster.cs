using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //SceneManager.LoadScene("Result");を動かすために必要
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public int boxNum;//現在存在するボックスの数　今回の場合、40が代入される
    public float nowTime;//ゲームが開始してからの秒数
    [SerializeField] Text resultMessageText; //ResultMessageTextゲームオブジェクトのTextコンポーネントのID番号が代入される。
    private bool isClear; //isClearがtrueならステージクリア状態、falseなら未ステージクリア状態。
    [SerializeField] private Score score; //ScoreCanvasゲームオブジェクトのScoreコンポーネント(=Scoreスクリプト)のID番号が代入される。

    // Use this for initialization
    void Start()
    {
        nowTime = 0; //ゲームが始まるので、ゲームが開始してからの秒数nowTimeを0にする。
    }

    // Update is called once per frame
    void Update()
    {
        //nowTimeに今までに経過した時間を入れています．Time.deltaTimeでは前のフレームから経過した時間を取得できます．Update()は毎フレーム実行されるのでその経過時間を毎フレーム足すことで経過時間を取得することができます
        nowTime += Time.deltaTime;

        if (!isClear) //もしステージクリアしてないなら
        {
            if (boxNum <= 0)
            {
                StageClear(nowTime.ToString("F0") + "秒でクリアできた!"); //nowTimeを小数点第0位まで(＝小数点以下なし)の文字列に変換した後、それに秒でクリアできた!という文字列をくっつけ、引数としてStageClear関数を呼び出す。
                isClear = true; //ステージクリアしたことにする
            }
        }

        /*
        //もし今のボックス数が0以下ならGameOver関数を呼び出し、Resultシーンに移動する。
        if (boxNum <= 0)
        {
            GameOver(nowTime.ToString("F0")+"秒でクリアできた!",true); //nowTime.ToString("F0")＝nowTimeを小数点第0位まで(＝小数点以下なし)の文字列に変換する
        }
        */

        if (Input.GetKeyDown(KeyCode.Escape)) //PCのESCキーやアンドロイド端末の戻るボタンが押されたら
        {
#if UNITY_EDITOR //ゲームを実行している環境がUnityEditorなら
            UnityEditor.EditorApplication.isPlaying=false; //UnityEditorの実行を停止(このあと実行されるプログラム(他のスクリプトを含む)も実行されなくなる)       
#else　//ゲームを実行している環境がUnityEditor以外(=WebGL、スマホ端末、PCなど。既にゲームの開発が終了している段階であり、本来の実行環境)なら
            Application.Quit(); //ゲームを終了する
#endif //#if文の終了
        }
    }

    void StageClear(string resultMessage) //何秒でクリアできたというString型の情報がresultMessageに代入される。
    {
        score.Save();　//ScoreスクリプトのSaveメソッドを呼び出し、ハイスコアを保存する。
        resultMessageText.text = resultMessage;　　　　　　　　　　　            //  画面にクリア状態を表示する(ResultTextのTextは空白にしておく)　　　　　　　　　　　
        FindObjectOfType<LevelManager>().LevelUp();                              //  LevelManagerのLevelUpメソッドを呼び出す             
    }

    public void GameOver(string resultMessage,bool isClear)
    {
        score.Save();//ScoreスクリプトのSaveメソッドを呼び出し、ハイスコアを保存する。

        DataSender.resultMessage = resultMessage; //Resultシーンに遷移すると、public staticがついていないresultMessage変数は消えてしまうので、DataSenderスクリプトのpublic staticがついたresultMessage変数に情報を代入しておく。

        DataSender.isClear = isClear;

        //Resultという名前の”シーン”に移動しろ．という命令
        SceneManager.LoadScene("Result");
    }
}