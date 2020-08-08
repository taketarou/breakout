using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //もしスペースキーが押されているなら
        if (Input.GetKey(KeyCode.Space)) 
        {
            //Mainという名前のシーンに移動する
            SceneManager.LoadScene("Main");
        }
    }
}
