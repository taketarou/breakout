using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class SceneSelecter : MonoBehaviour
{
    public enum SceneType //SceneTypeはenumクラス名を指し、SceneTypeクラスという意味。
    {
        Title,
        Main,
        Result
    }

    private SceneType sceneType;  // 現在のゲームシーンのID番号を代入するための参照型変数

    // Use this for initialization
    void Start()
    {
        //sceneName = SceneManager.GetActiveScene().name;       //現在のゲームシーンを取得して代入する

        //現在のゲームシーン名をSceneType型に変換し、そのID番号を参照型変数sceneTypeに代入する。
        sceneType = (SceneType)Enum.Parse(typeof(SceneType), SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        //もしスペースキーが押されたら
        if (Input.GetKey(KeyCode.Space))
        {
            switch (sceneType)
            {
                case SceneType.Title:
                    SceneManager.LoadScene(SceneType.Main.ToString());
                    break;

                case SceneType.Result:
                    SceneManager.LoadScene(SceneType.Title.ToString());
                    break;
            }


            /*
            //遷移させるゲームシーンをsceneName(=現在のゲームシーン)より決定する
            switch (sceneName)
            {                                
                case "Title":                                //  sceneNameがTitleなら
                    SceneManager.LoadScene("Main");          //  Mainシーンへ遷移する
                    break;
                case "Result":                               //  sceneNameがResultなら
                    SceneManager.LoadScene("Title");         //  Titleシーンへ遷移する
                    break;
                default:
                    break;
            }
            */
        }
    }
}
