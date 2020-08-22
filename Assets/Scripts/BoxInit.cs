using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInit : MonoBehaviour
{
    public GameObject[] boxObjPrefabs; //BoxのPrefabはboxObjPrefabs[0]、HardBoxのPrefabはboxObjPrefabs[1]に格納される。
    public GameObject boxesObj; //BoxesオブジェクトはboxesObj変数に格納される。

    //Awake関数内の処理はStartよりも先に実行される。
    void Awake()
    {
        //Hierarchyタブの中からMasterゲームオブジェクトを探してmasterobjに格納
        GameObject masterObj = GameObject.Find("Master");

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 5; y++) 
            {
                //0から配列boxObjPrefabsの要素数-1までの範囲で乱数を作って、それをrandomValueに格納する。0か1が格納される。
                int randomValue = Random.Range(0, boxObjPrefabs.Length);

                //Box、またはHardBoxを複製し、gに格納する(複製してできたオブジェクトは、boxesObjに格納されているBoxesゲームオブジェクトの子オブジェクトとなる)。
                GameObject g = Instantiate(boxObjPrefabs[randomValue], boxesObj.transform);

                //複製してできたオブジェクトの位置の変更
                g.transform.position = new Vector3((2f + (1f * y)), 0.4f, (-4.2f + (1.2f * x)));

                //DestroyerスクリプトのmasterobjにMasterゲームオブジェクトを格納
                g.GetComponent<Destroyer>().masterObj = masterObj; 
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
