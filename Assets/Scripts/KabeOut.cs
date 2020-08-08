using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KabeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //このスクリプトが適用されているゲームオブジェクトにオブジェクトがあたってきたとき、この関数は呼ばれる。あたってきたオブジェクトのID番号が引数として、参照型変数collisionに代入される。
    private void OnCollisionEnter(Collision collision)
    {
        //Masterオブジェクトの持つGameMasterコンポーネント(スクリプト)のGameOver関数を呼ぶ
        GameObject.Find("Master").GetComponent<GameMaster>().GameOver("ゲーム失敗. また挑戦しよう",false);
    }
}
