using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour //ScoreCanvasオブジェクトにアタッチされるスクリプト
{

    // スコアを表示するUIの取得用
    public Text scoreText; //ScoreTextゲームオブジェクトのID番号が代入される
    // ハイスコアを表示するUIの取得用
    public Text highScoreText; //HighScoreTextゲームオブジェクトのID番号が代入される

    // スコアのカウント用
    public static int score; 

    // ハイスコアのカウント用
    public static int highScore; //初期化されていないので、初期値として自動的に0が代入される。

    // PlayerPrefsで保存するためのキー(=データの保存、読み込み用のキー)
    private string highScoreKey = "highScore"; 

    //Start関数(他のスクリプトのStart関数も含む)よりも早く呼ばれる関数
    void Awake()
    {
        if (!LevelManager.isStart) //LevelManagerのisStart変数を反転したものがtrueなら(=LevelManagerのisStart変数がfalseなら)
        {
            Initialize();
        }
    }

    // ゲーム開始前の状態に設定
    private void Initialize()
    {
        // スコアを0に設定
        score = 0;

        // highScoreKeyに保存されているint型の値（＝過去の最高スコア・ハイスコア）を取得し、それをhighScoreへ代入する。highScoreKeyに値が保存されていなければ(=過去にブロック崩しをやっていなければ)、0を取得する。
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    // ポイントの追加。修飾子をpublicにしているので外部より参照できるメソッドになっている
    public void AddPoint(int point)　　　　　　//　外部より受け取ったint型の引数(=今回は10)をpointとして受け取る
    {
        score += point; //score=score+point

        // スコアがハイスコアより大きくなれば、ハイスコアを更新する
        if (highScore < score)
        {
            highScore = score;
        }

        // ゲーム画面上のスコアとハイスコアの表示を更新する
        DisplayScores();
    }

    // ゲーム画面上のスコアとハイスコアの表示を更新する
    private void DisplayScores()
    {
        // 現在のスコアとハイスコアを画面に表示する
        scoreText.text = score.ToString(); //ScoreTextゲームオブジェクトの文字列をscore(ToString関数でString型に変換されている)に格納されている値にする。
        highScoreText.text = highScore.ToString(); //HighScoreTextゲームオブジェクトの文字列をhighScore(ToString関数でString型に変換されている)に格納されている値にする。
    }

    // ハイスコアの保存
    public void Save()
    {
        // ハイスコアを保存する
        PlayerPrefs.SetInt(highScoreKey, highScore);//highScoreKeyというString型の変数に、highScoreに格納されているint型の値を保存する。
        PlayerPrefs.Save(); //保存を確定する(これによって、ゲームが終了しても(＝プログラムが終了しても)、highScoreに格納されたハイスコアをhighScoreKeyという変数を通して参照できるようになる)。

        Debug.Log(highScore);
    }
}

