using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelecter : MonoBehaviour
{

    private string sceneName;                 //  現在のゲームシーンを取得するための変数

    // Use this for initialization
    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;       //  現在のゲームシーンを取得して代入する
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {                    //  spaceボタンを押したときに、ゲームシーンを遷移する。
            switch (sceneName)
            {                                //  遷移させるゲームシーンをsceneNameより決定する
                case "Title":                                //  現在のシーンがTitleなら
                    SceneManager.LoadScene("Main");          //  Mainシーンへ遷移する
                    break;
                case "Result":                               //  現在のシーンがResultなら
                    SceneManager.LoadScene("Title");         //  Titleシーンへ遷移する
                    break;
                default:
                    break;
            }
        }
    }
}
