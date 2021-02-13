using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameManager : MonoBehaviour //QuitGameManagerCanvasにアタッチされているスクリプト
{
    public QuitCheckPopUp quitCheckPopUpPrefab; ///QuitCheckPopUpプレファブのID番号が代入される。
    public Transform canvasTran; //QuitGameManagerCanvasのRect Transform（位置）のID番号が代入される。

    //private QuitCheckPopUp quitCheckPopUp;
    [SerializeField] QuitCheckPopUp quitCheckPopUp = null; //プレハブから生成したポップアップのID番号を代入する変数

    void Awake()
    {
        //このスクリプトがアタッチされているゲームオブジェクト(=QuitGameManagerCanvas)がシーン遷移しても破棄されないようにする
        DontDestroyOnLoad(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        if (quitCheckPopUp == null&&Input.GetKeyDown(KeyCode.Escape)) //PCのESCキーやアンドロイド端末の戻るボタンが押されたら
        {
                //quitCheckPopUpPrefabという参照型変数に格納されているID番号が指し示すゲームオブジェクト(=QuitCheckPopUpプレファブ)と同じものを、canvasTranという参照型変数に格納されているID番号が指し示す位置・回転角(=QuitGameManagerCanvasのRect Transform)と同じ値で複製し、そのID番号を返す(複製してできたオブジェクトは、QuitGameManagerCanvasの子オブジェクトとなり、座標は親オブジェクトであるQuitGameManagerCanvasの位置から見たもの（＝相対座標、親オブジェクトであるQuitGameManagerCanvasの位置を0とする）となる)。そして、返されたID番号をquitCheckPopUpに代入する。
                quitCheckPopUp = Instantiate(quitCheckPopUpPrefab, canvasTran, false);
        }
    }

    /// <summary>
    /// ゲームの終了処理
    /// </summary>
    public static void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    

    }
}
