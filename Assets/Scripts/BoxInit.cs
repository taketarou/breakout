using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInit : MonoBehaviour
{
    //ゲームオブジェクトクラス型の参照型変数を定義。ゲームオブジェクトクラス型の参照型変数を定義すると、このスクリプトをアタッチしたゲームオブジェクトのInspectorタブに、定義したゲームオブジェクト型の参照型変数と同じ名前の項目が追加される。そして、Inspectorタブ上のBox Obj Prefabに指定したBoxのPrefabのID番号はboxObjPrefab変数に、Boxes Objに指定したBoxesオブジェクトのID番号はboxesObjオブジェクト変数にそれぞれ格納される。
    public GameObject[] boxObjPrefabs; 
    public GameObject boxesObj;

    //AwakeとはStartよりも早く呼ばれるイベント関数です．Awake関数内の処理はStartよりも先に実行されます．
    void Awake()
    {
        //Hierarchyタブの中からMasterゲームオブジェクトを探して、そのID番号をmasterobjに格納
        GameObject masterObj = GameObject.Find("Master");

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 5; y++) 
            {
                int randomValue = Random.Range(0, boxObjPrefabs.Length);

                GameObject g = Instantiate(boxObjPrefabs[randomValue], boxesObj.transform);

                //BoxのPrefab(=boxobjPrefabに格納されているID番号が示すオブジェクト)と同じものを複製する(複製してできたBoxオブジェクトは、Boxesオブジェクト(=boxesobjに格納されているID番号が示すオブジェクト)の子オブジェクトとなる)。そして、その複製したオブジェクト(ゲームオブジェクト)のID番号をGameObjectクラス型の参照型変数gに格納する。 　Instantiate関数は、オブジェクトを基にオブジェクトを生成する(=オブジェクトを複製する)関数。
                //GameObject g = Instantiate(boxObjPrefab, boxesObj.transform); //gはprefabと同じ位置に作られる。

                //gに格納されているID番号が指すオブジェクト(=Boxを複製したもの)のtransformのposition(のx,y,z)に2+(1 * y),0.4、-4.2+ (1.2 * x)をそれぞれ代入する。 Vector3の引数は全部float型。
                g.transform.position = new Vector3((2f + (1f * y)), 0.4f, (-4.2f + (1.2f * x)));　//prefabのxが4でboxesのxが2のときgのxは0  prefabのxが0でboxesのxが2のときgのxは0   prefab0 boxes4のとき-2  prefab2 boxes4のとき-2　 prefab0 boxes0のとき2   prefab6 boxes0のとき2  親の座標が0なら子の座標に関わらず、計算した結果の座標が正しく代入される。また親の座標が一緒なら子の座標が違くてもgには同じ座標が代入される。

                g.GetComponent<Destroyer>().masterObj = masterObj; //Boxを複製したもの(＝Box(Clone))が持っているDestroyerコンポーネント(=Destroyerスクリプト)の参照型変数masterobjにMasterゲームオブジェクトのID番号を格納
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
