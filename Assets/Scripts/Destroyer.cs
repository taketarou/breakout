using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public int point;
    public GameObject masterObj; //InspecterタブのMaster Objに指定したオブジェクトのID番号が格納されるが、この場合は、BoxInitスクリプトを通してMasterゲームオブジェクトのID番号が格納される。

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //このスクリプトが適用されているゲームオブジェクト(=ブロック)にオブジェクトがあたってきたとき、この関数は呼ばれる。あたってきたオブジェクトのID番号が引数として、参照型変数collisionに代入される。
    private void OnCollisionEnter(Collision collision) //privateなしでもいい？
    {
        FindObjectOfType<Score>().AddPoint(point); //ScoreスクリプトのAddPoint関数を呼び出し、スコアを加算する。　FindObjectOfTypeは主にコンポーネントの型を取るときに使う。

        //masterObjが示すゲームオブジェクト(=この場合は、Masterゲームオブジェクト)のGameMasterコンポーネント(=GameMasterスクリプト)の変数boxNumを－1する。
        masterObj.GetComponent<GameMaster>().boxNum--;

        Destroy(gameObject);
    }
}
