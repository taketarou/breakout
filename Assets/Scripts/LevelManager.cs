using System.Collections;
using System.Collections.Generic;
using UnityEngine; //Debugクラスも持っている
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] Text levelText=null;             //  レベルの表示用。インスペクタで指定可能。LevelTextゲームオブジェクトのTextコンポーネントのID番号が代入される。

    [SerializeField] StartShot startShot=null;        //  ボールの制御用。BallゲームオブジェクトのStartShotコンポーネント(=StartShotスクリプト)のID番号が代入される。

    public static int level;                     //  ステージをクリアした回数。シーンをまたいでも引き継ぐようにpublic かつ staticにする。

    public static bool isStart;                  //  ゲーム開始かどうかを判断するフラグ。falseならゲーム開始前。trueならゲーム中と判断する。初期化されていないのでbool型の変数isStartの初期値はfalse
   

    void Start()
    {
        if (!isStart)                             //  isStartのフラグを確認し、false(=ゲーム開始前)であれば実行される。「!isStart」は「isStart == false」と同義。
        {
            level = 0;                           //  レベルを0にする
            isStart = true;                      //  ゲーム開始(=ゲーム中)のフラグを立てる。タイトル画面へ戻るとリセットされるようにResetFlags.csで管理する
        }

        levelText.text = level.ToString();　　　 //  levelをLevelTextに表示(isStartがtrueでもfalseでも関係なく実行される)。
    }

    public void LevelUp()                        //  ステージをクリアしたときに外部（GameMaster.cs）より呼ばれるメソッド
    {
        startShot.BallDestroy();　　　　　　　　 //  ボールを制御するメソッド（＝StartShotスクリプトのBallDestroy関数）を呼び出し、ボールをゲーム画面から消す。
        level++;                               //  levelを加算する
        StartCoroutine("NextLevel");             //  コルーチンの呼出し。コルーチンを呼びだしたら、すぐコルーチン呼び出しの下にかかれている処理も実行する。コルーチンとコルーチン呼び出しの下にかかれている処理が並列で実行される感じ。        
    }

    IEnumerator NextLevel()                                   //  コルーチン(IEnumerator 関数名という形で記述する。IEnumeratorが戻り値の型)
    {
        Debug.Log("Please press key"); //コンソールにPlease press keyという文字列とDebug.Log関数が呼ばれた場所を出力する

        while (Input.GetKey("space")==false) //スペースキーが押されていない間、{}の中の処理を実行する。while (!Input.GetKey("space"))でも同じ意味。その場合、スペースキーが押されていなければInput.GetKey("space")でfalseが返り、!Input.GetKey("space")はInput.GetKey("space")の結果の反転だからtrueとなる。
        {
            yield return null;   //　スペースキーの入力待ち。1フレーム待つ(その後、yield return nullの次の処理を実行する)という意味。yieldがついているので、StartCouroutine("NextLevel");にnull(=1フレーム待つという情報)を返した後、while文をまた実行する。コルーチンではなく、普通の関数のwhile文内でreturnした場合は、戻り値を返した後、while文には戻らず、そのwhile文が書いてある関数自体を抜け出す。 
        }

        SceneManager.LoadScene("Main");                       //(スペースキーが押されたら)Mainシーンに移動する
        Debug.Log("Done!"); //コンソールにDone!という文字列とDebug.Log関数が呼ばれた場所を出力する。
    }//コルーチンの終了。コルーチンを途中で強制的に終了させたい場合は、yield break;を使う。
}
