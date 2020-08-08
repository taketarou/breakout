using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject masterObj; //InspecterタブのMaster Objに指定したオブジェクトのID番号が格納されるが、この場合は、BoxInitスクリプトを通してMasterゲームオブジェクトのID番号が格納される。

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //masterObjが示すゲームオブジェクト(=この場合は、Masterゲームオブジェクト)のGameMasterコンポーネント(=GameMasterスクリプト)の変数boxNumを－1する。
        masterObj.GetComponent<GameMaster>().boxNum--;

        Destroy(gameObject);
    }
}
